using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationManagement.Domain.Repositories;
using ReservationManagement.Infrastructure.Repository;

namespace ReservationManagement.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string sqlDatabaseConnectionString = configuration.GetConnectionString("DefaultConnection") 
                                             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlDatabaseConnectionString));

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}