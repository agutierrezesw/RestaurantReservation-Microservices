using MediatR;

namespace ReservationManagement.Application.Services.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    public Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
