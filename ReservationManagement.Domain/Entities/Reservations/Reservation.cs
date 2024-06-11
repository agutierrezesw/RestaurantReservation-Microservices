using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Reservations
{
    public class Reservation : Entity
    {
        public int RestaurantId { get; set; }
        public int CustomersId { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime DateAndTime { get; set; }

        public Reservation(int restaurantId, int customersId, int numberOfDiners, DateTime dateAndTime)
        {
            RestaurantId = restaurantId;
            CustomersId = customersId;
            NumberOfDiners = numberOfDiners;
            DateAndTime = dateAndTime;
        }
    }
}
