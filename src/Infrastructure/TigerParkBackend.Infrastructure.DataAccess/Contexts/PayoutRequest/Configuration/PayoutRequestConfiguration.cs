using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.PayoutRequest.Configuration;

using PayoutRequest = TigerParkBackend.Domain.PayoutRequest.PayoutRequest;

public class PayoutRequestConfiguration : IEntityTypeConfiguration<PayoutRequest>
{
    public void Configure(EntityTypeBuilder<PayoutRequest> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PayoutAmount).IsRequired();
        builder.Property(x => x.CreatedAt)
            .HasConversion(d => d, d => DateTime.SpecifyKind(d, DateTimeKind.Utc))
            .IsRequired();
        
        builder.HasOne(x => x.Partner)
            .WithOne(x => x.PayoutRequest)
            .HasForeignKey<PayoutRequest>(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}