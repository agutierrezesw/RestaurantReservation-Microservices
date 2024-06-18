using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationManagement.Domain.Entities.Restaurants;

namespace ReservationManagement.Infrastructure.Configuration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.MaxNumberOfSeats)
            .IsRequired();

        builder.HasMany(r => r.Reservations)
            .WithOne(r => r.Restaurant)
            .HasForeignKey(r => r.RestaurantId);
    }
}
