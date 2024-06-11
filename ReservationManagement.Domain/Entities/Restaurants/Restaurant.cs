using RestaurantReservation.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManagement.Domain.Entities.Restaurants
{
    public class Restaurant : Entity
    {
        public int MaxNumberOfSeats { get; set; }
    }
}
