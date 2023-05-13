using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.VehicleImage.Configuration;

using VehicleImage = TigerParkBackend.Domain.VehicleImage.VehicleImage;

public class VehicleImageConfiguration : IEntityTypeConfiguration<VehicleImage>
{
    public void Configure(EntityTypeBuilder<VehicleImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).IsRequired();
    }
}