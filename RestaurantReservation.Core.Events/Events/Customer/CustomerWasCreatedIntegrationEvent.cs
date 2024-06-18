using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public record CustomerWasCreatedIntegrationEvent : IIntegrationEvent
{
    public int Id;
    public string FirstName;
    public string LastName;
    public string Email;
    public int TotalNumberOfReservations;
    public string LastRestaurantReserved;
}