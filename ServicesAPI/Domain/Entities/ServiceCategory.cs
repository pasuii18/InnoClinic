namespace Domain.Entities;

public class ServiceCategory
{
    public Guid IdServiceCategory { get; set; }
    public string ServiceCategoryName { get; set; }
    public int TimeSlotSize { get; set; }
    public List<Service> Services { get; set; }
}