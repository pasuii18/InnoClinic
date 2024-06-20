using System.ComponentModel;
using Newtonsoft.Json;

namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentCreateDto(DateOnly Date, TimeOnly Time, Guid IdPatient, Guid IdDoctor, Guid IdService);