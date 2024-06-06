using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Customers;

namespace UserManagement.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> AddAndSaveAsync(Customer customer, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
