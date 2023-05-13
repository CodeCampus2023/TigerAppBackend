namespace TigerParkBackend.Domain.Vehicle;

public class Vehicle
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
    /// Изображение транспорта
    /// </summary>
    public virtual VehicleImage.VehicleImage? Image { get; set; }

    /// <summary>
    /// Идентификатор изображения
    /// </summary>
    public Guid? ImageId { get; set; }    
    
    /// <summary>
    /// Категория транспорта
    /// </summary>
    public virtual VehicleCategory.VehicleCategory? Category { get; set; }
    
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public Guid? CategoryId { get; set; }
}