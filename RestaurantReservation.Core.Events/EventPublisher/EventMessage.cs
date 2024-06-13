namespace RestaurantReservation.Core.Events.EventPublisher;

public class EventMessage(string eventName, string payload)
{
    public string EventName { get; set; } = eventName;
    public string Payload { get; set; } = payload;
}