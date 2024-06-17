using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationManagement.Domain.Entities.Reservations;

namespace ReservationManagement.Infrastructure.Configuration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.NumberOfDiners)
            .IsRequired();

        builder.Property(r => r.DateAndTime)
            .IsRequired();

        builder.HasOne(r => r.Restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.RestaurantId)
            .HasPrincipalKey(r => r.Id);

        builder.HasOne(r => r.Customer)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .HasPrincipalKey(r => r.Id);
    }
}
