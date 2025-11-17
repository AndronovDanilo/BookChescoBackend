using BookChescoAPI.Contracts.User;
using BookChescoDomain.Models;
using BookChescoDomain.Repositories;
using BookChescoInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookChescoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IPasswordHasher _passwordHasher;

    public UsersController(
        IUserRepository userRepository,
        ICloudinaryService cloudinaryService,
        IPasswordHasher passwordHasher
    )
    {
        _userRepository = userRepository;
        _cloudinaryService = cloudinaryService;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userRepository.GetAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userRepository.GetAsync(id);
        if (user is null)
            return NotFound();
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAndUpdateUserRequest request)
    {
        var newUser = new User
        {
            Login = request.Username,
            Email = request.Email,
            Password = _passwordHasher.Hash(request.Password),
            Role = request.Role
        };

        await _userRepository.CreateAsync(newUser);

        return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateAndUpdateUserRequest request)
    {
        var existingUser = await _userRepository.GetAsync(id);
        if (existingUser is null)
            return NotFound();

        existingUser.Login = request.Username;
        existingUser.Email = request.Email;
        existingUser.Password = _passwordHasher.Hash(request.Password);
        existingUser.Role = request.Role;

        await _userRepository.UpdateAsync(id, existingUser);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingUser = await _userRepository.GetAsync(id);
        if (existingUser is null)
            return NotFound();

        await _userRepository.RemoveAsync(id);

        return NoContent();
    }
}