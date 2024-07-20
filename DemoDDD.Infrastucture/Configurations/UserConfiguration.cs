using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Users;
using DemoDDD.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDDD.Infrastucture.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(x => x.Id);

        builder.Property(v => v.Names)
            .HasMaxLength(200)
            .HasConversion(v => v!.Value, value => new Name(value));

        builder.Property(v => v.Email)
            .HasMaxLength(200)
            .HasConversion(v => v!.Value, value => new Domain.Users.Email(value));

        builder.Property(v => v.LastName)
           .HasMaxLength(400)
           .HasConversion(v => v!.Value, value => new LastName(value));

        builder.HasIndex(v => v.Email)
            .IsUnique();
    }
}
