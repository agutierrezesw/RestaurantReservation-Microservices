using MediatR;
using ReservationManagement.Domain.Entities.Restaurants;
using ReservationManagement.Domain.Repositories;

namespace ReservationManagement.Application.Services.Commands.CreateOrUpdateRestaurant;

public class CreateOrUpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<CreateOrUpdateRestaurantCommand>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task Handle(CreateOrUpdateRestaurantCommand command, CancellationToken cancellationToken)
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
