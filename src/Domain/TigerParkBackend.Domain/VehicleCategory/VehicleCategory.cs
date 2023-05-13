namespace TigerParkBackend.Domain.VehicleCategory;

/// <summary>
/// Категория транспорта
/// </summary>
public class VehicleCategory
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
    /// Транспорт в категории
    /// </summary>
    public virtual IEnumerable<Vehicle.Vehicle> Vehicles { get; set; }
}