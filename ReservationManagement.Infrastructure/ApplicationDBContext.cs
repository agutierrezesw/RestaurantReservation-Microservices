namespace ReservationManagement.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Configuration;
using ReservationManagement.Domain.Entities.Customers;
using ReservationManagement.Domain.Entities.Restaurants;
using ReservationManagement.Domain.Entities.Reservations;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; init; }
    public DbSet<Restaurant> Restaurants { get; init; }
    public DbSet<Reservation> Reservations { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }
}