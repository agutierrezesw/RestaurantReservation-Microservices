using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Services.CustomerServices;

namespace UserManagement.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<CustomerService>();

        return services;
    }
}