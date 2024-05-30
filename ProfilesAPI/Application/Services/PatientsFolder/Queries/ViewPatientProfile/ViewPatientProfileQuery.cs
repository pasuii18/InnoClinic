using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Queries.ViewPatientProfile;

public class ViewPatientProfileQuery : IRequest<ICustomResult>
{
    public Guid IdPatient { get; set; }
}