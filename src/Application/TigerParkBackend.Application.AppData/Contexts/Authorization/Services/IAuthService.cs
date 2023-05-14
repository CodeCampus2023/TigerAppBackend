using TigerParkBackend.Contracts.Authorization;
using TigerParkBackend.Contracts.Partner;

namespace TigerParkBackend.Application.AppData.Contexts.Authorization.Services;

/// <summary>
/// Сервис авторизации
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрирует партнера
    /// </summary>
    /// <param name="dto">Модель партнера для регистрации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор партнера</returns>
    Task<Guid?> Register(RegisterPartnerDto dto, CancellationToken cancellationToken);
    
    /// <summary>
    /// Авторизирует партнера
    /// </summary>
    /// <param name="dto">Модель пользователя для авторизации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Токен авторизации</returns>
    Task<TokenDto> Login(LoginPartnerDto dto, CancellationToken cancellationToken);
}