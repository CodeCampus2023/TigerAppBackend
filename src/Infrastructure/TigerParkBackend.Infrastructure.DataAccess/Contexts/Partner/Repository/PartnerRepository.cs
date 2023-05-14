using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TigerParkBackend.Application.AppData.Contexts.Partner.Repositories;
using TigerParkBackend.Infrastructure.Repository;

namespace TigerParkBackend.Infrastructure.DataAccess.Contexts.Partner.Repository;

using Partner = TigerParkBackend.Domain.Partner.Partner;

public class PartnerRepository : IPartnerRepository
{
    private readonly IRepository<Partner> _repository;
    private readonly IMapper _mapper;

    public PartnerRepository(IRepository<Partner> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> Add(Partner partner, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(partner, cancellationToken);
        return (Guid)partner.Id!;
    }

    public async Task<Partner?> FindWhere(Expression<Func<Partner, bool>> expression, CancellationToken cancellationToken)
    {
        return await _repository.GetAllFiltered(expression).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsPhoneExist(string phone, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAll().AnyAsync(x => x.Phone == phone);
        return result;
    }
}