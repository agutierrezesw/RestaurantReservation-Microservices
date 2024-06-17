using Microsoft.EntityFrameworkCore;
using ReservationManagement.Domain.Entities.Reservations;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Infrastructure.Repository;

public class ReservationRepository(ApplicationDbContext context) : IReservationRepository
{
    private readonly ApplicationDbContext _dbContext = context;
    private readonly DbSet<Reservation> _dbSet = context.Set<Reservation>();

    public Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(id, cancellationToken).AsTask();
    }

    public async Task<int> AddAndSaveAsync(Reservation restaurant, CancellationToken cancellationToken = default)
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