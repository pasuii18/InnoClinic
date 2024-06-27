using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Commands.DeletePatient;

public class DeletePatientCommand : IRequest<ICustomResult>
{
    public Guid IdPatient { get; set; }
}