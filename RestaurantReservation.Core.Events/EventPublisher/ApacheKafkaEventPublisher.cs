using System.Text.Json;
using Confluent.Kafka;
using RestaurantReservation.Core.Events.Contracts;
using RestaurantReservation.Core.Events.Events;

namespace RestaurantReservation.Core.Events.EventPublisher;

/// <summary>
/// Implementation of the event publisher using Confluent Kafka platform
/// </summary>
public class ApacheKafkaEventPublisher(IProducer<Null, EventMessage> producer) : IEventPublisher
{
    /// <summary>
    /// Event list and the topic where dispatch event messages
    /// </summary>
    private readonly Dictionary<string, List<string>> _eventTopics = new()
    {
        { typeof(CustomerWasCreatedIntegrationEvent).FullName!, ["user-management"] }
    };

    /// <inheritdoc />
    public async Task<bool> Publish(IIntegrationEvent @event)
    {
        var eventName = @event.GetType().FullName ?? throw new Exception("Invalid event object");
        var topics = _eventTopics.First(keyPair => keyPair.Key == eventName);
        // Cannot find topics for event
        if (topics.Value.Count == 0)
        {
            throw new Exception($"No topic configured for event {eventName}");
        }
        
        foreach (var topic in topics.Value)
        {
            var eventMessage = new EventMessage(eventName, JsonSerializer.Serialize(@event, @event.GetType()));
            await producer.ProduceAsync(topic, new Message<Null, EventMessage>
            {
                Value = eventMessage
            });
        }

        return true;
    }
}