using MediatR;
using ReservationManagement.Application.Services.Commands.CreateOrUpdateRestaurant;
using RestaurantReservation.Core.Events.Events.Customer;

namespace ReservationManagement.Application.Services.Events.Restaurant;

class RestaurantWasUpdatedEventHandler(IMediator mediator) : INotificationHandler<RestaurantWasUpdatedIntegrationEvent>
{
    private readonly IMediator Mediator = mediator;

    public Task Handle(RestaurantWasUpdatedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        CreateOrUpdateRestaurantCommand command = new(@event.Id, @event.MaxNumberOfSeats);
        return Mediator.Send(command, cancellationToken);
    }
}
