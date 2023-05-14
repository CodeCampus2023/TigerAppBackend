using System.ComponentModel.DataAnnotations;

namespace TigerParkBackend.Contracts.Partner;

/// <summary>
/// Модель регистрации пользователя
/// </summary>
public class RegisterPartnerDto
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    [StringLength(64, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string Name { get; set; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}