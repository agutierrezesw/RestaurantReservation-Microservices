namespace RestaurantReservation.Core.Events.Contracts;

using MediatR;

/// <summary>
/// Contract for Integration Events launched by every service
/// </summary>
public interface IIntegrationEvent: INotification
{
}