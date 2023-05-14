using TigerParkBackend.Contracts.Partner;

namespace TigerParkBackend.Application.AppData.Contexts.Partner.Services;

public interface IPartnerService
{
    Task<Guid> Create(CreatePartnerDto dto, CancellationToken cancellationToken);
    Task<bool> IsPhoneExist(string phone, CancellationToken cancellationToken);
}