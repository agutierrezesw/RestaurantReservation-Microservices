namespace UserManagement.Infrastructure;

using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Infrastructure.Configuration;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    public DbSet<Customer> Customers { get; init; }
}