namespace TigerParkBackend.Domain.PayoutRequest;

/// <summary>
/// Запрос на выдачу средств
/// </summary>
public class PayoutRequest
{
    /// <summary>
    ///Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Сумма на вывод
    /// </summary>
    public decimal PayoutAmount { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Партнер запросивший вывод
    /// </summary>
    public virtual Partner.Partner? Partner { get; set; }
    
    /// <summary>
    /// Идентификатор партнера
    /// </summary>
    public Guid? PartnerId { get; set; }
}