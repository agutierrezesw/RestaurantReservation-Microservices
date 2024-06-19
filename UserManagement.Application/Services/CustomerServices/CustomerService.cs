using RestaurantReservation.Core.Events.Contracts;
using RestaurantReservation.Core.Events.Events.Customer;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Services.CustomerServices
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventPublisher _eventPublisher;

        public CustomerService(ICustomerRepository customerRepository, IEventPublisher eventPublisher)
        {
            _customerRepository = customerRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<int> CreateCustomerAsync(NewCustomerRequest request)
        {
            // Create a new customer entity
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            // Add the customer to the repository
            await _customerRepository.AddAndSaveAsync(customer);

            await _eventPublisher.Publish(
                new CustomerWasCreatedIntegrationEvent(
                    Id: customer.Id,
                    FirstName: customer.FirstName,
                    LastName: customer.LastName,
                    Email: customer.Email,
                    TotalNumberOfReservations: customer.TotalNumberOfReservations,
                    LastRestaurantReserved: customer.LastRestaurantReserved
                )
            );

            return 1;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            // Delete the customer from the repository
            await _customerRepository.DeleteByIdAsync(id);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            // Get the customer from the repository
            return await _customerRepository.GetByIdAsync(id);
        }
    }
}
