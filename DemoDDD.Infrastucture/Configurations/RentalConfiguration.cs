using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Users;
using DemoDDD.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDDD.Infrastucture.Configurations;

internal sealed class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable(nameof(Rental));
        builder.HasKey(t => t.Id);

        builder.OwnsOne(v => v.PerPeriodPrice, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.OwnsOne(v => v.Accesories, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.OwnsOne(v => v.MaintenancePrice, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.OwnsOne(v => v.TotalPrice, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.OwnsOne(v => v.Duration);

        builder.HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(r => r.VehicleId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.UserId);
    }
}
