using MediatR;

namespace ReservationManagement.Application.Services.Commands.CreateOrUpdateRestaurant;

public record CreateOrUpdateRestaurantCommand(int Id, int MaxNumberOfSeats) : IRequest;