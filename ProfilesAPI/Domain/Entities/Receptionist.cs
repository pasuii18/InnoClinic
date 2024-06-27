namespace Domain.Entities;

public class Receptionist
{
    public Guid IdReceptionist { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid IdAccount { get; set; }
    public string IdOffice { get; set; }
}