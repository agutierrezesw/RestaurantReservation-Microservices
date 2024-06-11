using MediatR;
using ReservationManagement.Domain.Repositories;
using RestaurantReservation.Core.Application.Events;
using ReservationManagement.Domain.Entities.Customers;

namespace ReservationManagement.Application.Services.Events
{
    class CreateCustomerHandler : INotificationHandler<CustomerCreatedEvent>
    {
        private ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            Customer customer = new() { Id = notification.Id };
            await _customerRepository.AddAndSaveAsync(customer, cancellationToken);
        }
    }
}
