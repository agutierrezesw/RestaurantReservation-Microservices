using RestaurantReservation.Core.Events.Contracts;

namespace RestaurantReservation.Core.Events.Events.Customer;

public record ReservationWasCreatedIntegrationEvent : IIntegrationEvent
{
    public int Id;
    public int NumberOfDiners;
    public DateTime DateAndTime;
    public int RestaurantId;
    public int CustomerId;
}