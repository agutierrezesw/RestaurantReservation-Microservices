namespace RestaurantReservation.Core.Events.Contracts;

/// <summary>
/// Contract for the integration event publisher
/// </summary>
public interface IEventPublisher
{
    /// <summary>
    /// Publish an event
    /// </summary>
    /// <param name="event"></param>
    /// <returns></returns>
    Task<bool> Publish(IIntegrationEvent @event);
}