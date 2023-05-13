namespace TigerParkBackend.Domain.BonusTransaction;

/// <summary>
/// Транзакции бонусов
/// </summary>
public class BonusTransaction
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Бонус
    /// </summary>
    public decimal Bonus { get; set; }
    
    /// <summary>
    /// Партнер
    /// </summary>
    public virtual Partner.Partner? Partner { get; set; }
    
    /// <summary>
    /// Идентификатор партнера
    /// </summary>
    public Guid? PartnerId { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
}