using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Reviews;
using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Users;
using DemoDDD.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDDD.Infrastucture.Configurations;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable(nameof(Review));
        builder.HasKey(x => x.Id);
        builder.OwnsOne( v=> v.Commentary );

        builder.Property(v => v.Rating)
            .HasConversion(v => v!.Value, value => Rating.Create(value).Value);

        builder.Property(v => v.Commentary)
            .HasMaxLength(200)
            .HasConversion(v => v!.Value, value => new Commentary(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.UserId);

        builder.HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(r => r.VehicleId);

        builder.HasOne<Rental>()
            .WithMany()
            .HasForeignKey(r => r.RentId);
    }
}
