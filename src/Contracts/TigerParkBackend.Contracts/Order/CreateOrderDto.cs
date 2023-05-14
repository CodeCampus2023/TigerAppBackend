using System.ComponentModel.DataAnnotations;

namespace TigerParkBackend.Contracts.Order;

public class CreateOrderDto
{
    [Required]
    [Phone]
    public string ClientPhone { get; set; }
    
    [Required]
    [StringLength(64, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string ClientName { get; set; }
    
    [Required]
    [StringLength(128, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string ClientStatus { get; set; }
    
    [Required]
    [StringLength(512, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string Pickup { get; set; }
    
    [Required]
    [StringLength(512, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string Destination { get; set; }
    
    [Required]
    [StringLength(1024, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string Track { get; set; }
    
    [Required]
    public Guid? Vehicle { get; set; }
    
    [Required]
    public int? PorterCount { get; set; }
    
    [StringLength(2048, ErrorMessage = "{0} cannot be more than {1} and less than {2}", MinimumLength = 2)]
    public string? Comment { get; set; }
}