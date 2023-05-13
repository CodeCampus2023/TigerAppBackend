using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.Vehicle.Configuration;

using Vehicle = TigerParkBackend.Domain.Vehicle.Vehicle;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(x => x.Image)
            .WithOne()
            .HasForeignKey<Vehicle>(x => x.ImageId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}