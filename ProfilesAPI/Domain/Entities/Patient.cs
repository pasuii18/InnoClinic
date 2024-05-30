namespace Domain.Entities;

public class Patient
{
    public Guid IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid? IdAccount { get; set; }
    public Account? Account { get; set; }
}