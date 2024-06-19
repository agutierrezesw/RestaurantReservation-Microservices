using MediatR;
using ReservationManagement.Application.Services.Commands.CreateOrUpdateCustomer;
using RestaurantReservation.Core.Events.Events.Customer;

namespace ReservationManagement.Application.Services.Events.Customer;

class CustomerWasUpdatedEventHandler(IMediator mediator) : INotificationHandler<CustomerWasUpdatedIntegrationEvent>
{
    private readonly IMediator Mediator = mediator;

    public Task Handle(CustomerWasUpdatedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        CreateOrUpdateCustomerCommand command = new(@event.Id);
        return Mediator.Send(command, cancellationToken);
    }
}
