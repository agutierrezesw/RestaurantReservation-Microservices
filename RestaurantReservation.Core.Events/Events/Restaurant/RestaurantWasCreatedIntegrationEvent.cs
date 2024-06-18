using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public class RestaurantWasCreatedIntegrationEvent(int id, string name, int MaxNumberOfSeats) : IIntegrationEvent
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int MaxNumberOfSeats { get; set; } = MaxNumberOfSeats;
}