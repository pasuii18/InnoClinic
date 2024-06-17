namespace Application.Common.Dtos.AppointmentsDtos;

public class AppointmentCreateDto
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public bool IsApproved { get; set; }
    public Guid IdPatient { get; set; } // patient -> auto gen, admin -> handwrite
    public Guid IdDoctor { get; set; }
    public Guid IdService { get; set; }
}

// specialization - combobox

// date - datepicker
// time slots - table with slots
// doctor - combobox
// service - combobox
// office - dropdown


// for admin

// specialization - combobox

// patient - combobox ---------------- new
// date - datepicker
// time slots - table with slots
// doctor - combobox
// service - combobox
// office - dropdown