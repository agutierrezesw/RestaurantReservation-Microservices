using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Entities.Restaurants;
using RestaurantManagement.Domain.Repositories;

namespace RestaurantManagement.Infrastructure.Repository
{
    public class InMemoryRestaurantRepository: IRestaurantRepository
    {
        private static readonly List<Restaurant> _items = [];
        public InMemoryRestaurantRepository() { }

        public Task<Restaurant?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var restaurant = _items != null ? _items.FirstOrDefault(i => i.Id == id) : null;

            return Task.FromResult(restaurant);
        }

        public Task<int> AddAndSaveAsync(Restaurant item, CancellationToken cancellationToken)
        {
            int id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
            item.Id = id;
            _items.Add(item);

            return Task.FromResult(item.Id);
        }

        public Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            _items.RemoveAll(i => i.Id == id);

            return Task.CompletedTask;
        }
    }
}
