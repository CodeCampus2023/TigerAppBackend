using System.Linq.Expressions;

namespace TigerParkBackend.Application.AppData.Contexts.Partner.Repositories;

using Partner = TigerParkBackend.Domain.Partner.Partner;

public interface IPartnerRepository
{
    Task<Guid> Add(Partner partner, CancellationToken cancellationToken);
    Task<Partner?> FindWhere(Expression<Func<Partner, bool>> expression, CancellationToken cancellationToken);
    Task<bool> IsPhoneExist(string phone, CancellationToken cancellationToken);
}