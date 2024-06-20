namespace ReservationManagement.Application.Services.ReservationService.Requests;

public class NewReservationRequest
{
    public int RestaurantId { get; set; }
    public int CustomerId { get; set; }
    public int NumberOfDiners { get; set; }
    public DateTime DateTime { get; set; }
}
