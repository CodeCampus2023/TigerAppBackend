namespace TigerParkBackend.Domain.ClientStatus;

/// <summary>
/// Возможный статус общения с клиентом
/// </summary>
public class ClientStatus
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Статус
    /// </summary>
    public string Status { get; set; }
}