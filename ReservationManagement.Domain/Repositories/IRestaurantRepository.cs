using ReservationManagement.Domain.Entities.Restaurants;

namespace ReservationManagement.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> AddAndSaveAsync(Restaurant restaurant, CancellationToken cancellationToken = default);

        Task<int> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
