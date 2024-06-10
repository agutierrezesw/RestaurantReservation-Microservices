using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Entities.Restaurants;
using RestaurantManagement.Infrastructure.Configuration;

namespace RestaurantManagement.Infrastructure
{
    internal class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
        }

        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
