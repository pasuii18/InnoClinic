using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctorProfile;

public class ViewDoctorProfileQueryHandler : IRequestHandler<ViewDoctorProfileQuery, ICustomResult>
{
    public Task<ICustomResult> Handle(ViewDoctorProfileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}