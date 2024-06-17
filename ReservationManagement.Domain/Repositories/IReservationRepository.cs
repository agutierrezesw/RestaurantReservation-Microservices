using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> AddAndSaveAsync(Reservation restaurant, CancellationToken cancellationToken = default);

        Task<int> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
