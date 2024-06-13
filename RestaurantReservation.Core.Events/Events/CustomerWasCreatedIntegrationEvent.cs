using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events;

public class CustomerWasCreatedIntegrationEvent(int id, string firstName, string lastName) : IIntegrationEvent
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}