namespace TigerParkBackend.Domain.Partner;

/// <summary>
/// Партнер
/// </summary>
public class Partner
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Захэшированный пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Бонусы
    /// </summary>
    public decimal Bonuses { get; set; }
    
    /// <summary>
    /// Активные заказы
    /// </summary>
    public virtual IEnumerable<Order.Order> Orders { get; set; }
    
    /// <summary>
    /// Завершенные заказы
    /// </summary>
    public virtual IEnumerable<CompletedOrder.CompletedOrder> CompletedOrders { get; set; }
    
    /// <summary>
    /// Транзакции бонусов
    /// </summary>
    public virtual IEnumerable<BonusTransaction.BonusTransaction> BonusTransactions { get; set; }
    
    /// <summary>
    /// Запрос на вывод средств
    /// </summary>
    public virtual PayoutRequest.PayoutRequest? PayoutRequest { get; set; }
    
    /// <summary>
    /// Идентификатор запроса на вывод средств
    /// </summary>
    public Guid? PayoutRequestId { get; set; }
}