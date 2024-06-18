using ReservationManagement.Domain.Entities.Customers;
using ReservationManagement.Domain.Entities.Restaurants;
using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Reservations;

public class Reservation : Entity
{
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int NumberOfDiners { get; set; }
    public DateTime DateAndTime { get; set; }
}
