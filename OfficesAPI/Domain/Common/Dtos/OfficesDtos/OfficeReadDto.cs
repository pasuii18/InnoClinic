namespace Domain.Common.Dtos.OfficesDtos;

public class OfficeReadDto
{
    public Guid IdOffice { get; set; }
    public string Address { get; set; }
    public string RegistryPhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public Guid IdPhoto { get; set; }
}