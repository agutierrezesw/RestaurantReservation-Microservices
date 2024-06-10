using RestaurantManagement.Domain.Entities.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> AddAndSaveAsync(Restaurant restaurant, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
