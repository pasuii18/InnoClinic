using Application.Interfaces;
using Domain.Common.Enums;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.UpdateDoctorStatus;

public class UpdateDoctorStatusCommand : IRequest<ICustomResult>
{
    public Guid IdDoctor { get; set; }
    public DoctorStatus Status { get; set; }
}