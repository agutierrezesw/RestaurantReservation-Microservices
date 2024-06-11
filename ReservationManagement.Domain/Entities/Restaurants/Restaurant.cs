using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Restaurants
{
    public class Restaurant : Entity
    {
        public int MaxNumberOfSeats { get; set; }
    }
}
