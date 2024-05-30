using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Queries.ViewPatients;

public class ViewPatientsQueryHandler : IRequestHandler<ViewPatientsQuery, ICustomResult>
{
    public Task<ICustomResult> Handle(ViewPatientsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}