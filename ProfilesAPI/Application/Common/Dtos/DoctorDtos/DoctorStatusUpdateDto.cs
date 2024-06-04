using Application.Services.DoctorsFolder.Commands.EditDoctorStatus;
using Domain;

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