using MediatR;
using ReservationManagement.Application.Services.Commands.CreateRestaurant;
using RestaurantReservation.Core.Events.Events.Customer;

namespace ReservationManagement.Application.Services.Events.Restaurant;

class RestaurantWasCreatedEventHandler(IMediator mediator) : INotificationHandler<RestaurantWasCreatedIntegrationEvent>
{
    private readonly IMediator Mediator = mediator;

    public Task Handle(RestaurantWasCreatedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        CreateRestaurantCommand command = new(@event.Id, @event.MaxNumberOfSeats);
        return Mediator.Send(command, cancellationToken);
    }
}
