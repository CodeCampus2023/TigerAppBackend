using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.Order.Configuration;

using Order = TigerParkBackend.Domain.Order.Order;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ClientPhone).HasMaxLength(15).IsRequired();
        builder.Property(x => x.ClientName).HasMaxLength(64).IsRequired();
        builder.Property(x => x.ClientStatus).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Pickup).HasMaxLength(512).IsRequired();
        builder.Property(x => x.Destination).HasMaxLength(512).IsRequired();
        builder.Property(x => x.Track).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.PorterCount).IsRequired();
        builder.Property(x => x.Comment).HasMaxLength(2048);

        builder.HasOne(x => x.Vehicle)
            .WithOne()
            .HasForeignKey<Order>(x => x.VehicleId)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired();

        builder.HasOne(x => x.Partner)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}