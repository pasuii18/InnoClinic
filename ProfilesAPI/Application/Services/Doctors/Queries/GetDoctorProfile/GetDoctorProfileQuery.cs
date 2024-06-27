using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctorProfile;

public class GetDoctorProfileQuery : IRequest<ICustomResult>
{
    public Guid IdDoctor { get; set; }
}