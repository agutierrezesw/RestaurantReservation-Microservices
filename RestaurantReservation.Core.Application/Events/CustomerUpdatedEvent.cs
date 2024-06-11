using MediatR;

namespace RestaurantReservation.Core.Application.Events
{
    public record CustomerUpdatedEvent(
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
