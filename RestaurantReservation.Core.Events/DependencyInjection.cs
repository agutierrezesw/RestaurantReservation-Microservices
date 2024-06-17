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
        var bootstrapServers = configuration["ApacheKafka:BootstrapServers"]
                               ?? throw new Exception("Bootstrap server is not configured");

        // Add event publisher kafka implementation
        services.AddScoped<IEventPublisher, ApacheKafkaEventPublisher>(_ =>
        {
            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };

            var producer = new ProducerBuilder<Null, IIntegrationEvent>(config)
                .SetValueSerializer(new EventMessageSerializer())
                .Build();

            var eventPublisher = new ApacheKafkaEventPublisher(producer);

            return eventPublisher;
        });

        // Add kafka consumer
        return services.AddSingleton<ConsumerBuilder<Null, IIntegrationEvent>>(_ =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = configuration["ApacheKafka:GroupId"]
            };

            return new ConsumerBuilder<Null, IIntegrationEvent>(config)
                .SetValueDeserializer(new EventMessageSerializer());
        });
    }
}