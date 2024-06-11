using MediatR;

namespace RestaurantReservation.Core.Application.Events
{
    public record CustomerCreatedEvent(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        int TotalNumberOfReservations,
        string LastRestaurantReserved
    ) : INotification
    {
    }
}
