using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Queries.ViewPatientProfile;

public class ViewPatientProfileQueryHandler : IRequestHandler<ViewPatientProfileQuery, ICustomResult>
{
    public Task<ICustomResult> Handle(ViewPatientProfileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}