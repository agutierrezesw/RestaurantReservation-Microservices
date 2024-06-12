using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Repository;

public class CustomerRepository(ApplicationDBContext context) : ICustomerRepository
{
    private readonly ApplicationDBContext _dbContext = context;
    private readonly DbSet<Customer> _dbSet = context.Set<Customer>();

    public Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken).AsTask();
    }

    public Task<int> AddAndSaveAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        var result = _dbSet.AddAsync(customer, cancellationToken).AsTask();

        return Task.FromResult(result.IsCompleted ? 1 : 0);
    }

    public async Task<int> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is null)
        {
            return 0;
        }

        _dbSet.Remove(entity);
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}