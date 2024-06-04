using Application.Services.DoctorsFolder.Commands.UpdateDoctorStatus;
using Domain;
using Domain.Common.Enums;

namespace Application.Common.Dtos.DoctorDtos;

public record DoctorStatusUpdateDto(Guid IdDoctor, DoctorStatus Status)
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