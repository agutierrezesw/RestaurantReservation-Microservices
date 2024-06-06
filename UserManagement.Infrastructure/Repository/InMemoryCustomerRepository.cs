using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Repository
{
    internal class InMemoryCustomerRepository: ICustomerRepository
    {
        private static readonly List<Customer> _items = [];
        public InMemoryCustomerRepository() { }

        Task<Customer?> ICustomerRepository.GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var customer = _items != null ? _items.FirstOrDefault(i => i.Id == id) : null;

            return Task.FromResult(customer);
        }

        Task<int> ICustomerRepository.AddAndSaveAsync(Customer item, CancellationToken cancellationToken)
        {
            int id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
            item.Id = id;
            _items.Add(item);

            return Task.FromResult(item.Id);
        }

        Task ICustomerRepository.DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            _items.RemoveAll(i => i.Id == id);

            return Task.CompletedTask;
        }
    }
}
