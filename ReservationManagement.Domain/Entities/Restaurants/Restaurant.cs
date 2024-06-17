using RestaurantReservation.Core.Domain.Abstractions;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Domain.Entities.Restaurants;

public class Restaurant(int maxNumberOfSeats) : Entity
{
    public int MaxNumberOfSeats { get; set; } = maxNumberOfSeats;
    public List<Reservation> Reservations { get; set; } = [];
}
