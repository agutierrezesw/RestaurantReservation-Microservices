using MediatR;

namespace ReservationManagement.Application.Services.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand>
{
    public Task Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
