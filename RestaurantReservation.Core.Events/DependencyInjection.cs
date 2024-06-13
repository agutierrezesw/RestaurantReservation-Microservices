using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Confluent.Kafka;
using RestaurantReservation.Core.Events.Contracts;
using RestaurantReservation.Core.Events.EventPublisher;

namespace RestaurantReservation.Core.Events;

public static class DependencyInjection
{
    /// <summary>
    /// Create a new publisher instance
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddEventInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        return services.AddScoped<IEventPublisher, ApacheKafkaEventPublisher>(_ =>
        {
            var config = new ProducerConfig
            {
                BootstrapServers = configuration["ApacheKafka:BootstrapServers"] 
                                   ?? throw new Exception("Config not found")
            };

            var producer = new ProducerBuilder<Null, EventMessage>(config)
                .SetValueSerializer(new EventMessageSerializer())
                .Build(); 

            var eventPublisher = new ApacheKafkaEventPublisher(producer);

            return eventPublisher;
        });
    }
}