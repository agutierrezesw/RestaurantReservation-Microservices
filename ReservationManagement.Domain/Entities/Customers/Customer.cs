using ReservationManagement.Domain.Entities.Reservations;
using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Customers;

public class Customer : Entity
{
    public List<Reservation> Reservations { get; set; } = [];
}
