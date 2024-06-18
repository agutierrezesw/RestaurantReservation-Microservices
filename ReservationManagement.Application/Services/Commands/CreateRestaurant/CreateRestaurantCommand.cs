using MediatR;

namespace ReservationManagement.Application.Services.Commands.CreateRestaurant;

public record CreateRestaurantCommand(int Id, int MaxNumberOfSeats) : IRequest;