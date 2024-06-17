using Microsoft.EntityFrameworkCore;
using ReservationManagement.Domain.Entities.Restaurants;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Infrastructure.Repository;

public class RestaurantRepository(ApplicationDbContext context) : IRestaurantRepository
{
    private readonly ApplicationDbContext _dbContext = context;
    private readonly DbSet<Restaurant> _dbSet = context.Set<Restaurant>();

    public Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken).AsTask();
    }

    public async Task<int> AddAndSaveAsync(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(restaurant, cancellationToken);
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