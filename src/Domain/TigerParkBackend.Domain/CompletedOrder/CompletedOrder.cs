namespace TigerParkBackend.Domain.CompletedOrder;

/// <summary>
/// Завершенный заказ
/// </summary>
public class CompletedOrder
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public string ClientPhone { get; set; }
    
    /// <summary>
    /// Имя клиента
    /// </summary>
    public string ClientName { get; set; }

    /// <summary>
    /// Точка подачи
    /// </summary>
    public string Pickup { get; set; }
    
    /// <summary>
    /// Точка доставки
    /// </summary>
    public string Destination { get; set; }
   
    /// <summary>
    /// Бонусы, полученные от заказа партнером
    /// </summary>
    public decimal Cost { get; set; }
    
    /// <summary>
    /// Процент от заказа, по которому считался Cost
    /// </summary>
    public decimal Percent { get; set; }
    
    /// <summary>
    /// Партнер, создавший заказ
    /// </summary>
    public virtual Partner.Partner? Partner { get; set; }
    
    /// <summary>
    /// Идентификатор партнера
    /// </summary>
    public Guid? PartnerId { get; set; }
}