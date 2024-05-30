using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctors;

public class ViewDoctorsQueryHandler : IRequestHandler<ViewDoctorsQuery, ICustomResult>
{
    public Task<ICustomResult> Handle(ViewDoctorsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}