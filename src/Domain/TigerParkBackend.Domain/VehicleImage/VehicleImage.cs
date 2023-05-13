namespace TigerParkBackend.Domain.VehicleImage;

/// <summary>
/// Изображение транспорта
/// </summary>
public class VehicleImage
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Изображение
    /// </summary>
    public byte[] Content { get; set; }
}