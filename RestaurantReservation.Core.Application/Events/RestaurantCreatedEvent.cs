using MediatR;

namespace RestaurantReservation.Core.Application.Events
{
    public record RestaurantCreatedEvent(
        int Id,
        string Name,
        int MaxNumberOfSeats
    ) : INotification
    {
    }
}
