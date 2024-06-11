using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Repository;

namespace UserManagement.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string sqlDatabaseConnectionString = configuration.GetConnectionString("SqlDatabaseConnectionString") 
                                             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDBContext>(options => options.UseMySQL(sqlDatabaseConnectionString));

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
