using MediatR;
using ReservationManagement.Domain.Repositories;
using ReservationManagement.Domain.Entities.Customers;

namespace ReservationManagement.Application.Services.Commands.CreateOrUpdateCustomer;

public class CreateOrUpdateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateOrUpdateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task Handle(CreateOrUpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        Customer? customer = await _customerRepository.GetByIdAsync(command.Id);

        if (customer == null)
        {
            customer = new Customer { Id = command.Id };
            await _customerRepository.AddAndSaveAsync(customer, cancellationToken);
        }
    }
}
