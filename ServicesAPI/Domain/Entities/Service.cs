namespace Domain.Entities;

public class Service
{
    public Guid IdService { get; set; }
    public string ServiceName { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public Guid IdServiceCategory { get; set; }
    public Guid IdSpecialization { get; set; }
}