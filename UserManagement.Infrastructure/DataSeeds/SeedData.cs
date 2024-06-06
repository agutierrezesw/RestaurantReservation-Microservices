using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Repository;

namespace UserManagement.Infrastructure.DataSeeds
{
    public class SeedData
    {
        public void SeedDataToRepository(ICustomerRepository repository)
        {
            var faker = new Faker();

            for (int i = 0; i < 10; i++)
            {
                var customer = new Customer
                {
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Email = faker.Internet.Email()
                };

                repository.AddAndSaveAsync(customer).Wait();
            }
        }
    }
}
