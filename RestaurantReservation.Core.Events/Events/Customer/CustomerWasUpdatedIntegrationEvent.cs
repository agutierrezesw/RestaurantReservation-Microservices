using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public class CustomerWasUpdatedIntegrationEvent(int id, string firstName, string lastName, string email, int? totalNumberOfReservations, string? lastRestaurantReserved) : IIntegrationEvent
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public int TotalNumberOfReservations { get; set; } = totalNumberOfReservations ?? 0;
    public string LastRestaurantReserved { get; set; } = lastRestaurantReserved ?? string.Empty;
}