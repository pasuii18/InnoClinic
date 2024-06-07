namespace Domain.Entities;

public class Specialization
{
    public Guid IdSpecialization { get; set; }
    public string SpecializationName { get; set; }
    public bool IsActive { get; set; }
    public List<Service> Services { get; set; }
}