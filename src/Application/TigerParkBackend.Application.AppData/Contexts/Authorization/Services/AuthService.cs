using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TigerParkBackend.Application.AppData.Contexts.Partner.Repositories;
using TigerParkBackend.Application.AppData.Exceptions;
using TigerParkBackend.Contracts.Authorization;
using TigerParkBackend.Contracts.Partner;

namespace TigerParkBackend.Application.AppData.Contexts.Authorization.Services;

/// <inheritdoc cref="IAuthService"/>
public class AuthService : IAuthService
{
    private readonly IPartnerRepository _partnerRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(IPartnerRepository partnerRepository, IMapper mapper, IConfiguration configuration)
    {
        _partnerRepository = partnerRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<Guid?> Register(RegisterPartnerDto dto, CancellationToken cancellationToken)
    {
        var isPhoneAlreadyExist = await _partnerRepository.IsPhoneExist(dto.PhoneNumber, cancellationToken);
        if (isPhoneAlreadyExist) return null;
        var password = CreatePassword(8);
        Console.WriteLine(password);
        var partner = _mapper.Map<Domain.Partner.Partner>(dto);
        partner.Password = EncryptPassword(password);
        return await _partnerRepository.Add(partner, cancellationToken);
    }

    public async Task<TokenDto> Login(LoginPartnerDto dto, CancellationToken cancellationToken)
    {
        var partner = await _partnerRepository.FindWhere(x => x.Phone == dto.Phone, cancellationToken);
        if (partner is null) throw new InvalidLoginDataException();
        
        var encryptedPassword = EncryptPassword(dto.Password);
        if (partner.Password != encryptedPassword) throw new InvalidLoginDataException();

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, partner.Id.ToString()!),
            new(ClaimTypes.Name, partner.Name)
        };

        var secretKey = _configuration["Jwt:SecurityKey"]!;
        var issuer = _configuration["Jwt:Issuer"]!;
        var audience = _configuration["Jwt:Audience"]!;

        var token = new JwtSecurityToken(
            claims: claims,
            issuer: issuer,
            audience: audience,
            expires: DateTime.UtcNow.AddHours(6),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256)
        );

        var result = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenDto() { Token = result };
    }
    
    private string CreatePassword(int length)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        return res.ToString();
    }
    
    private string EncryptPassword(string password)
    {
        var md5 = MD5.Create();
        var passBytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = md5.ComputeHash(passBytes);
        return Convert.ToHexString(hashBytes);
    }
}