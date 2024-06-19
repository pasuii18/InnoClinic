using Application.Interfaces;
using Domain.Common;

namespace Application.Common.Dtos.Filters;

public record AppointmentsFilter(DateOnly? Date, string? DoctorFullName, string? ServiceName,
    AppointmentStatus AppointmentStatus, Guid? IdOffice, OrderBy OrderBy, OrderType OrderType) : IFilterBase;

// The table should be ordered ascending by time

// The table should be ordered descending by date
// + equal dates Then this appointments should be ordered ascending by time

// The table should be ordered ascending by time
// for doctors schedule




// The page should contain the datepicker for filtration by appointment date
// The page should contain the field for filtration by doctor full name
// The page should contain the field for filtration by service name
// The page should contain the field for filtration by appointment status (Approved, Not Approved, All)
// The page should contain the field for filtration by office

// Given the appointments’ times are equal - Then they should be alphabetically ordered ascending by doctor surname
// Given the appointments’ times are equal, And the appointments’ doctor surnames are equal 
// - Then they should be alphabetically ordered ascending by doctor name

// Given the appointments’ times are equal,
// And the appointments’ doctor surnames are equal, 
// And the appointments’ doctor names are equal
// - Then they should be alphabetically ordered ascending by service name

// The list can be filtered by several fields at the same time