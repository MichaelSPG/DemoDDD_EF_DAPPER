using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDDD.Infrastucture.Configurations;

internal sealed class VechicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable(nameof(Vehicle));
        builder.HasKey(x => x.Id);
        builder.OwnsOne( v=> v.Address );

        builder.Property(v => v.Model)
            .HasMaxLength(200)
            .HasConversion(v => v!.Value, value => new Model(value));

        builder.Property(v => v.Vin)
            .HasMaxLength(500)
            .HasConversion(v => v!.Value, value => new Vin(value));

        builder.OwnsOne(v => v.Price, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.OwnsOne(v => v.MaintenanceAmount, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.Property<uint>("Version").IsRowVersion();
    }
}
