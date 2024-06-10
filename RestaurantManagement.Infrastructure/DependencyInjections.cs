using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Repositories;
using RestaurantManagement.Infrastructure.Repository;

namespace RestaurantManagement.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //string sqlDatabaseConnectionString = configuration.GetConnectionString("SqlDatabaseConnectionString") ?? throw new ArgumentNullException(nameof(configuration));
            string inMemoryDatabaseName = configuration["InMemoryDatabaseName"] ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase(inMemoryDatabaseName));

            services.AddScoped<IRestaurantRepository, InMemoryRestaurantRepository>();

            return services;
        }
    }
}
