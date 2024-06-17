namespace Domain.Entities;

public class Result
{
    public Guid IdResult { get; set; }
    public string Complaints { get; set; }
    public string Conclusion { get; set; }
    public string Recomendations { get; set; }
    public Guid IdAppointment { get; set; }
    public Appointment Appointment { get; set; }
}