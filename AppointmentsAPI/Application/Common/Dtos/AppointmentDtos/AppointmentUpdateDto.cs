namespace Application.Common.Dtos.AppointmentsDtos;

public class AppointmentUpdateDto
{
    public Guid IdAppointment { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public Guid IdDoctor { get; set; }
}