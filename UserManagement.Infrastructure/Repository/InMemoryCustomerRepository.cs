using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Repository
{
    public class InMemoryCustomerRepository: ICustomerRepository
    {
        private static readonly List<Customer> _items = [];
        public InMemoryCustomerRepository() { }

        public Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = _items != null ? _items.FirstOrDefault(i => i.Id == id) : null;

            return Task.FromResult(customer);
        }

        public Task<int> AddAndSaveAsync(Customer item, CancellationToken cancellationToken)
        {
            int id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
            item.Id = id;
            _items.Add(item);

            return Task.FromResult(item.Id);
        }

        public Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            _items.RemoveAll(i => i.Id == id);

            return Task.CompletedTask;
        }
    }
}
