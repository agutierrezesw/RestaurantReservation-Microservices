using MediatR;

namespace RestaurantReservation.Core.Application.Events
{
    public record RestaurantUpdatedEvent(
        int Id,
        string Name,
        int MaxNumberOfSeats
    ) : INotification
    {
    }
}
