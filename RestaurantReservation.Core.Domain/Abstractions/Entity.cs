using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Core.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(int id)
        {
            Id = id;
        }

        protected Entity()
        {
        }

        public int Id { get; set; }
    }
}
