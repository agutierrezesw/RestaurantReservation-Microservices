using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Services.CustomerServices
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
            return await _customerRepository.AddAndSaveAsync(customer);
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
