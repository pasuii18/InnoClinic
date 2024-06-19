namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentCreateDto(DateOnly Date, TimeOnly Time, Guid IdPatient, Guid IdDoctor, Guid IdService);
// patient -> auto gen, admin -> handwrite

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