using MediatR;
using ReservationManagement.Application.Services.Commands.CreateCustomer;
using RestaurantReservation.Core.Events.Events.Customer;

namespace ReservationManagement.Application.Services.Events.Customer;

class CustomerWasCreatedEventHandler(IMediator mediator) : INotificationHandler<CustomerWasCreatedIntegrationEvent>
{
    private readonly IMediator Mediator = mediator;

    public Task Handle(CustomerWasCreatedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        CreateCustomerCommand command = new(@event.Id);
        return Mediator.Send(command, cancellationToken);
    }
}
