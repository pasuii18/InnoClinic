using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;

public class ViewReceptionistProfileQueryHandler : IRequestHandler<ViewReceptionistProfileQuery, ICustomResult>
{
    public Task<ICustomResult> Handle(ViewReceptionistProfileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}