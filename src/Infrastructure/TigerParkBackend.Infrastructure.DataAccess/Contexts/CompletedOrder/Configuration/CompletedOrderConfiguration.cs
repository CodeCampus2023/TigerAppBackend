using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.CompletedOrder.Configuration;

using CompletedOrder = TigerParkBackend.Domain.CompletedOrder.CompletedOrder;

public class CompletedOrderConfiguration : IEntityTypeConfiguration<CompletedOrder>
{
    public void Configure(EntityTypeBuilder<CompletedOrder> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ClientPhone).HasMaxLength(15).IsRequired();
        builder.Property(x => x.ClientName).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Pickup).HasMaxLength(512).IsRequired();
        builder.Property(x => x.Destination).HasMaxLength(512).IsRequired();
        builder.Property(x => x.Cost).IsRequired();
        builder.Property(x => x.Percent).IsRequired();
        
        builder.HasOne(x => x.Partner)
            .WithMany(x => x.CompletedOrders)
            .HasForeignKey(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}