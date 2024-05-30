using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;

public class ViewReceptionistsQueryHandler : IRequestHandler<ViewReceptionistsQuery, ICustomResult>
{
    public Task<ICustomResult> Handle(ViewReceptionistsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}