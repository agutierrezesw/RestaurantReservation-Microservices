using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public record CustomerWasCreatedIntegrationEvent(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    int TotalNumberOfReservations,
    string LastRestaurantReserved
): IIntegrationEvent;