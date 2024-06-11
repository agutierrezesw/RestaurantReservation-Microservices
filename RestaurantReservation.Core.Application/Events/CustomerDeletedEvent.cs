using MediatR;

namespace RestaurantReservation.Core.Application.Events
{
    public record CustomerDeletedEvent(
        int Id
    ) : INotification
    {
    }
}
