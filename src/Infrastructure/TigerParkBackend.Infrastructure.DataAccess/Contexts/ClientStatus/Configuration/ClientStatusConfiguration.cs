using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.ClientStatus.Configuration;

using ClientStatus = TigerParkBackend.Domain.ClientStatus.ClientStatus;

public class ClientStatusConfiguration : IEntityTypeConfiguration<ClientStatus>
{
    public void Configure(EntityTypeBuilder<ClientStatus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).IsRequired();
    }
}