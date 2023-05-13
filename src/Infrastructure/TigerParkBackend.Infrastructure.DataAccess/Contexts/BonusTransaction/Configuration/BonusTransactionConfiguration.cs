using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.BonusTransaction.Configuration;

using BonusTransaction = TigerParkBackend.Domain.BonusTransaction.BonusTransaction;

public class BonusTransactionConfiguration : IEntityTypeConfiguration<BonusTransaction>
{
    public void Configure(EntityTypeBuilder<BonusTransaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Bonus).IsRequired();
        
        builder.HasOne(x => x.Partner)
            .WithMany(x => x.BonusTransactions)
            .HasForeignKey(x => x.PartnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}