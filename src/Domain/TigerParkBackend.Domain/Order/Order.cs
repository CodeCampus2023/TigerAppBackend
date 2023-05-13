namespace TigerParkBackend.Domain.Order;

/// <summary>
/// Активный заказ
/// </summary>
public class Order
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
    /// Статус общения с клиентом
    /// </summary>
    public string ClientStatus { get; set; }
    
    /// <summary>
    /// Точка подачи
    /// </summary>
    public string Pickup { get; set; }
    
    /// <summary>
    /// Точка доставки
    /// </summary>
    public string Destination { get; set; }
    
    /// <summary>
    /// Маршрут
    /// </summary>
    public string Track { get; set; }
    
    /// <summary>
    /// Кол-во грузчиков
    /// </summary>
    public int PorterCount { get; set; }
    
    /// <summary>
    /// Комментарий к заказу
    /// </summary>
    public string? Comment { get; set; }
    
    /// <summary>
    /// Партнер, создавший заказ
    /// </summary>
    public virtual Partner.Partner? Partner { get; set; }
    
    /// <summary>
    /// Идентификатор партнера
    /// </summary>
    public Guid? PartnerId { get; set; }
    
    /// <summary>
    /// Транспорт
    /// </summary>
    public virtual Vehicle.Vehicle? Vehicle { get; set; }
    
    /// <summary>
    /// Идентификатор транспорта
    /// </summary>
    public Guid? VehicleId { get; set; }
}