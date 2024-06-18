using RestaurantReservation.Core.Domain.Abstractions;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Domain.Entities.Restaurants;

public class Restaurant : Entity
{
    public int MaxNumberOfSeats { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = [];
}
