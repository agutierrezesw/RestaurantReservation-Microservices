using Confluent.Kafka;
using System.Text.Json;
using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.EventPublisher;

/// <summary>
/// Base serialize for building raw event message from event
/// </summary>
public class EventMessageSerializer: ISerializer<IIntegrationEvent>, IDeserializer<IIntegrationEvent>
{
    public byte[] Serialize(IIntegrationEvent data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data, data.GetType());
    }

    public IIntegrationEvent Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        var header = context.Headers.First(h => h.Key == "EventName")
                        ?? throw new Exception("Cannot deserialize event");

        var eventName = header.GetValueBytes().ToString()
                        ?? throw new Exception("Cannot resolve event name");

        var eventType = Type.GetType(eventName)
                        ?? throw new Exception("Cannot resolve event type");


        return (IIntegrationEvent)(JsonSerializer.Deserialize(data, eventType) 
                                   ?? throw new Exception("Event is empty"));
    }
}