namespace UserManagement.Domain.Entities.Customers;

using RestaurantReservation.Core.Domain.Abstractions;

public class Customer : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int TotalNumberOfReservations { get; set; } = 0;
    public string LastRestaurantReserved { get; set; } = string.Empty;
}
