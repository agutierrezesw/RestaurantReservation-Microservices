using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Reservations
{
    public class Reservation : Entity
    {
        public int RestaurantId { get; set; }
        public List<int> CustomersIds { get; set; }

        public Reservation(int restaurantId, List<int> customersIds)
        {
            RestaurantId = restaurantId;
            CustomersIds = customersIds;
        }
    }
}
