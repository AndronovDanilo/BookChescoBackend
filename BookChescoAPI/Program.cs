using BookChescoInfrastructure.Configuration;
using BookChescoInfrastructure.Services;
using BookChescoInfrastructure.Repositories;
using BookChescoDomain.Repositories;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<CloudinarySettings>>().Value;
    var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
    return new Cloudinary(account);
});
builder.Services.AddSingleton<ICloudinaryService, CloudinaryService>();

// Register EF Core DbContext (SQL Server). Uses connection string "DefaultConnection" from configuration
// with a safe fallback to localdb for development if not provided.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                         ?? "Server=(localdb)\\mssqllocaldb;Database=BookChescoDb;Trusted_Connection=True;"));

// Register repositories (EF Core implementations)
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
