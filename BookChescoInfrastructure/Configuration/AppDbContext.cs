using Microsoft.EntityFrameworkCore;
using BookChescoDomain.Models;
namespace BookChescoInfrastructure.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Photo> Photos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("xxx");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Rooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Bookings)
            .WithOne(b => b.Room)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Hotel>()
            .HasMany(h => h.Photos)
            .WithMany(p => p.Hotels)
            .UsingEntity(j => j.ToTable("HotelPhotos"));
        
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Photos)
            .WithMany(p => p.Rooms)
            .UsingEntity(j => j.ToTable("RoomPhotos"));
    }
}