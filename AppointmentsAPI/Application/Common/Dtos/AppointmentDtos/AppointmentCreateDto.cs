using System.ComponentModel;
using Application.Common.Dtos.SlotDtos;
using Newtonsoft.Json;

namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentCreateDto(UpdateSlotStatusDto UpdateSlotStatusDto, 
    Guid IdPatient, Guid IdDoctor, Guid IdService);