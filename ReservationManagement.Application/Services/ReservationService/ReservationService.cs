using ReservationManagement.Domain.Repositories;
using ReservationManagement.Domain.Entities.Reservations;
using ReservationManagement.Application.Services.ReservationService.Requests;

namespace ReservationManagement.Application.Services.ReservationServices;

public class ReservationService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public ReservationService(ICustomerRepository customerRepository, IReservationRepository reservationRepository, IRestaurantRepository restaurantRepository)
    {
        _customerRepository = customerRepository;
        _reservationRepository = reservationRepository;
        _restaurantRepository = restaurantRepository;
    }

    public async Task<int> CreateReservationAsync(NewReservationRequest request)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

        if (customer == null)
        {
            throw new ArgumentException($"Unknown customer {request.CustomerId}");
        }

        var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null)
        {
            throw new ArgumentException($"Unknown restaurant {request.RestaurantId}");
        }

        var reservation = new Reservation
        {
            Customer = customer,
            CustomerId = customer.Id,
            Restaurant = restaurant,
            RestaurantId = restaurant.Id,
            NumberOfDiners = request.NumberOfDiners,
            DateAndTime = request.DateTime
        };

        await _reservationRepository.AddAndSaveAsync(reservation);

        return reservation.Id;
    }

    public async Task<Reservation?> GetReservationByIdAsync(int id)
    {
        return await _reservationRepository.GetByIdAsync(id);
    }

    public async Task DeleteReservationAsync(int id)
    {
        await _reservationRepository.DeleteByIdAsync(id);
    }
}
