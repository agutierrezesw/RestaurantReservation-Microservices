using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities.Customers;

namespace UserManagement.Infrastructure.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.TotalNumberOfReservations)
                .IsRequired();

            builder.Property(c => c.LastRestaurantReserved)
                .HasMaxLength(100);
        }
    }
}
