namespace TigerParkBackend.Contracts.Partner;

public class CreatePartnerDto
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public decimal Bonuses { get; set; }
}