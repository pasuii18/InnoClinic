using Application.Common;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Services.DoctorsFolder.Commands.EditDoctorStatus;

public class EditDoctorStatusCommand : IRequest<ICustomResult>
{
    public Guid IdDoctor { get; set; }
    public DoctorStatus Status { get; set; }
}