using MediatR;

namespace RestaurantReservation.Core.Application.Events
{
    public record RestaurantDeletedEvent(
        int Id
    ) : INotification
    {
    }
}
