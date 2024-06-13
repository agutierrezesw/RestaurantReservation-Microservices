namespace UserManagement.Domain.Repositories;

using Entities.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<int> AddAndSaveAsync(Customer customer, CancellationToken cancellationToken = default);

    Task<int> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}
