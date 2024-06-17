using ReservationManagement.Domain.Entities.Customers;
using ReservationManagement.Domain.Entities.Restaurants;
using RestaurantReservation.Core.Domain.Abstractions;

namespace ReservationManagement.Domain.Entities.Reservations;

public class Reservation(Restaurant restaurant, Customer customer, int numberOfDiners, DateTime dateAndTime) : Entity
{
    public int RestaurantId { get; set; } = restaurant.Id;
    public Restaurant Restaurant { get; set; } = restaurant;
    public int CustomerId { get; set; } = customer.Id;
    public Customer Customer { get; set; } = customer;
    public int NumberOfDiners { get; set; } = numberOfDiners;
    public DateTime DateAndTime { get; set; } = dateAndTime;
}
