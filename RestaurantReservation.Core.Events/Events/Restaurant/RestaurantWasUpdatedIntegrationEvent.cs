using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public record RestaurantWasUpdatedIntegrationEvent : IIntegrationEvent
{
    public int Id;
    public string Name;
    public int MaxNumberOfSeats;
}