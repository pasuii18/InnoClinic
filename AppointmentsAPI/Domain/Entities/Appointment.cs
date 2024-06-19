using Microsoft.VisualBasic;

namespace Domain.Entities;

public class Appointment
{
    public Guid IdAppointment { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public bool IsApproved { get; set; }
    public Guid IdPatient { get; set; }
    public Guid IdDoctor { get; set; }
    public Guid IdService { get; set; }
    public Result? Result { get; set; }
}