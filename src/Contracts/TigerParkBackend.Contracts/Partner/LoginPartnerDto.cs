namespace TigerParkBackend.Contracts.Partner;

/// <summary>
/// Модель авторизации партнера
/// </summary>
public class LoginPartnerDto
{
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}