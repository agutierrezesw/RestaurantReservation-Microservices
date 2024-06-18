using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public record RestaurantWasCreatedIntegrationEvent : IIntegrationEvent
{
    public int Id;
    public string Name;
    public int MaxNumberOfSeats;
}