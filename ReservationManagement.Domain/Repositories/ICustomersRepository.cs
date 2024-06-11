using ReservationManagement.Domain.Entities.Customers;

namespace ReservationManagement.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> AddAndSaveAsync(Customer customer, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
