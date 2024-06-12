namespace Domain.Entities;

public class Specialization : BaseEntity
{
    public Guid IdSpecialization { get; set; }
    public string SpecializationName { get; set; }
    public bool IsActive { get; set; }
    public List<Service>? Services { get; set; }
}