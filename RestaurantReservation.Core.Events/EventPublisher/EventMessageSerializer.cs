using Confluent.Kafka;
using System.Text.Json;

namespace RestaurantReservation.Core.Events.EventPublisher;

/// <summary>
/// Base serialize for building raw event message from event
/// </summary>
public class EventMessageSerializer: ISerializer<EventMessage>
{
    public byte[] Serialize(EventMessage data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data);
    }
}