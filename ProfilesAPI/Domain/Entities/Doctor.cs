using Domain.Common.Enums;

namespace Domain.Entities;

public class Doctor
{
    public Guid IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }
    public DoctorStatus Status { get; set; }
    public Guid IdAccount { get; set; }
    public Guid IdSpecialization { get; set; }
    public Guid IdOffice { get; set; }
}