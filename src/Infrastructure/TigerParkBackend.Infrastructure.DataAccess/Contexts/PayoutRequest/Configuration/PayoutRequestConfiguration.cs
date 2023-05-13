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
        
        builder.HasOne(x => x.Partner)
            .WithOne(x => x.PayoutRequest)
            .HasForeignKey<Domain.Partner.Partner>(x => x.PayoutRequestId)
            .HasForeignKey<PayoutRequest>(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}