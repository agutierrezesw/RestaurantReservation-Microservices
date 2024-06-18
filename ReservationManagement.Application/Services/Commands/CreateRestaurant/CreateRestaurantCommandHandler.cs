using MediatR;
using ReservationManagement.Domain.Entities.Restaurants;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Application.Services.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurantCommand>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await _restaurantRepository.GetByIdAsync(command.Id);

        if (restaurant == null)
        {
            restaurant = new Restaurant {
                Id = command.Id,
                MaxNumberOfSeats = command.MaxNumberOfSeats
            };
            await _restaurantRepository.AddAndSaveAsync(restaurant, cancellationToken);
        }
    }
}
