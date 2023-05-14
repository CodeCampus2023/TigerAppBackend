using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TigerParkBackend.Application.AppData.Contexts.Authorization.Services;
using TigerParkBackend.Application.AppData.Contexts.Partner.Repositories;
using TigerParkBackend.Application.AppData.Contexts.Partner.Services;
using TigerParkBackend.Infrastructure.DataAccess;
using TigerParkBackend.Infrastructure.DataAccess.Contexts.Partner.Repository;
using TigerParkBackend.Infrastructure.DataAccess.Interfaces;
using TigerParkBackend.Infrastructure.Repository;

namespace TigerParkBackend.Host.Api;

/// <summary>
/// Методы расширения для класса <see cref="Program"/>
/// </summary>
public static class ExtensionMethods
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        serviceCollection.AddScoped<IPartnerRepository, PartnerRepository>();
    }
    
    /// <summary>
    /// Добавить сервисы в DI
    /// </summary>
    /// <param name="serviceCollection">Сервисы программы</param>
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IPartnerService, PartnerService>();
    }
    
    /// <summary>
    /// Добавляет и настраивает аутентификацию на основе JWT токенов
    /// </summary>
    /// <param name="services">Сервис провайдер</param>
    public static void AddJwtAuthenticationWithOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSecurityKey = configuration["Jwt:SecurityKey"]!;
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateActor = false,
                    ValidateTokenReplay = false,
                    
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey))
                };
            });
    }
    
    /// <summary>
    /// Добавить DbContext с конфигурациями в DI
    /// </summary>
    /// <param name="serviceCollection">Сервисы программы</param>
    public static void AddDbContextWithConfigurations(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextOptionsConfigurator<AppDbContext>, AppDbContextConfiguration>();
        serviceCollection.AddDbContext<AppDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
            ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<AppDbContext>>()
                .Configure((DbContextOptionsBuilder<AppDbContext>)dbOptions)));
        serviceCollection.AddScoped((Func<IServiceProvider, DbContext>) (sp => sp.GetRequiredService<AppDbContext>()));
    }
}