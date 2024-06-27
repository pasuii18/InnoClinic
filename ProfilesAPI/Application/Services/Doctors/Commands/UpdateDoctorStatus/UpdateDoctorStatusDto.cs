using Application.Services.DoctorsFolder.Commands.UpdateDoctorStatus;
using Domain.Common.Enums;

namespace Application.Common.Dtos.DoctorDtos;

public record UpdateDoctorStatusDto(Guid IdDoctor, DoctorStatus Status)
{
    public UpdateDoctorStatusCommand MapInCommand()
    {
        return new UpdateDoctorStatusCommand
        {
            IdDoctor = IdDoctor,
            Status = Status
        };
    }
}