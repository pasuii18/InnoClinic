using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces;
using MediatR;

namespace Application.Services.DoctorsFolder.Queries.ViewDoctors;

public class GetDoctorsQuery : IRequest<ICustomResult>
{
    public PageSettings PageSettings { get; set; }
    public DoctorFilters DoctorFilters { get; set; }
}