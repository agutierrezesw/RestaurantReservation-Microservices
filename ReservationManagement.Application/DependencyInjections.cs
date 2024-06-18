using Microsoft.Extensions.DependencyInjection;
using ReservationManagement.Application.Services.ReservationServices;

namespace ReservationManagement.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ReservationService>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjections).Assembly);
        });

        return services;
    }
}