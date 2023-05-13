using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.Partner.Configuration;

using Partner = TigerParkBackend.Domain.Partner.Partner;

public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Bonuses).IsRequired();

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Partner)
            .HasForeignKey(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        
        builder.HasMany(x => x.CompletedOrders)
            .WithOne(x => x.Partner)
            .HasForeignKey(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        
        builder.HasMany(x => x.BonusTransactions)
            .WithOne(x => x.Partner)
            .HasForeignKey(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasOne(x => x.PayoutRequest)
            .WithOne(x => x.Partner)
            .HasForeignKey<Partner>(x => x.PayoutRequestId)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);
    }
}