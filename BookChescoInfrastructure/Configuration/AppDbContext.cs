using Microsoft.EntityFrameworkCore;
using BookChescoDomain.Models;
namespace BookChescoInfrastructure.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("xxx");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}