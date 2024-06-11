using ReservationManagement.Domain.Repositories;
using MediatR;

namespace ReservationManagement.Application.Services.ReservationServices
{
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
    }
}
