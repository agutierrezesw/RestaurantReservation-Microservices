using RestaurantReservation.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities.Customers
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TotalNumberOfReservations { get; set; } = 0;
        public string LastRestaurantReserved { get; set; }
    }
}
