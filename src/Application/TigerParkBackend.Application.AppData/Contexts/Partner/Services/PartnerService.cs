using AutoMapper;
using TigerParkBackend.Application.AppData.Contexts.Partner.Repositories;
using TigerParkBackend.Contracts.Partner;

namespace TigerParkBackend.Application.AppData.Contexts.Partner.Services;

using Partner = TigerParkBackend.Domain.Partner.Partner;

public class PartnerService : IPartnerService
{
    private readonly IPartnerRepository _partnerRepository;
    private readonly IMapper _mapper;

    public PartnerService(IPartnerRepository partnerRepository, IMapper mapper)
    {
        _partnerRepository = partnerRepository;
        _mapper = mapper;
    }
    
    public async Task<Guid> Create(CreatePartnerDto dto, CancellationToken cancellationToken)
    {
        var partner = _mapper.Map<Partner>(dto);
        var result = await _partnerRepository.Add(partner, cancellationToken);
        return result;
    }

    public async Task<bool> IsPhoneExist(string phone, CancellationToken cancellationToken)
    {
        return await _partnerRepository.IsPhoneExist(phone, cancellationToken);
    }
}