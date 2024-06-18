using MediatR;
using ReservationManagement.Domain.Repositories;
using ReservationManagement.Domain.Entities.Customers;

namespace ReservationManagement.Application.Services.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetByIdAsync(command.Id);

        if (customer == null)
        {
            customer = new Customer { Id = command.Id };
            await _customerRepository.AddAndSaveAsync(customer, cancellationToken);
        }
    }
}
