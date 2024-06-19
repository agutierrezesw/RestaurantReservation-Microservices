using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Consumer;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjections
{
    /// <summary>
    /// Add event processor worker
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddEventProcessorWorker(
        this IServiceCollection services, 
        IConfiguration configuration
        )
    {
        var topic = configuration.GetValue<string>("EventProcessor:Topic")!;

        services.AddHostedService<EventProcessorWorker>(serviceProvider => new EventProcessorWorker(
            logger: serviceProvider.GetRequiredService<ILogger<EventProcessorWorker>>(),
            builder: serviceProvider.GetRequiredService<ConsumerBuilder<Null, IIntegrationEvent>>(),
            serviceScopeFactory: serviceProvider.GetRequiredService<IServiceScopeFactory>(),
            topic: topic
        ));

        return services;
    }
}