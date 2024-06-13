using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Customers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Repository;

public class CustomerRepository(ApplicationDbContext context) : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext = context;
    private readonly DbSet<Customer> _dbSet = context.Set<Customer>();

    public Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken).AsTask();
    }

    public async Task<int> AddAndSaveAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(customer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return 1;
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