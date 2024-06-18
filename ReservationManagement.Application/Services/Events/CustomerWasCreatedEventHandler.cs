using MediatR;
using RestaurantReservation.Core.Events.Events;

namespace ReservationManagement.Application.Services.Events;

class CustomerWasCreatedEventHandler : INotificationHandler<CustomerWasCreatedIntegrationEvent>
{
    public Task Handle(CustomerWasCreatedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
