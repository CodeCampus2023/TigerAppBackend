using AutoMapper;
using TigerParkBackend.Contracts.Partner;
using TigerParkBackend.Domain.Partner;

namespace TigerParkBackend.Infrastructure.MapProfiles;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<CreatePartnerDto, Partner>(MemberList.Source)
            .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
            .ForMember(d => d.Password, map => map.MapFrom(s => s.Password))
            .ForMember(d => d.Phone, map => map.MapFrom(s => s.Phone))
            .ForMember(d => d.Bonuses, map => map.MapFrom(s => s.Bonuses));
        
        CreateMap<RegisterPartnerDto, Partner>(MemberList.None)
            .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
            .ForMember(d => d.Phone, map => map.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Bonuses, map => map.MapFrom(s => 0));
    }
}