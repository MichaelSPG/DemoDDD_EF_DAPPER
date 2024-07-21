using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace DemoDDD.Infrastucture.Configurations;

internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
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

        var accesorioListConverter = new ValueConverter<List<Accesory>, string>(
                v => string.Join(";", v.Select(a => (int)a)),
                v => 
                v.
                Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .Select(val => 
                        (Accesory)Enum.Parse(typeof(Accesory), val)).ToList());

        builder.Property(v => v.Accesories)
            .HasConversion(accesorioListConverter);

        builder.OwnsOne(v => v.Price, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder.OwnsOne(v => v.MaintenanceAmount, pBuilder => {
            pBuilder.Property(curency => curency.CurrencyKind)
            .HasConversion(cType => cType.Code, code => CurrencyKind.FromCode(code!));
        });

        builder
            .Property<uint>("Version")
            .HasDefaultValue(0)
            .IsRowVersion()
            .IsConcurrencyToken();
    }
}
