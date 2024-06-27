using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces;
using MediatR;

namespace Application.Services.PatientsFolder.Queries.ViewPatients;

public class GetPatientsQuery : IRequest<ICustomResult>
{
    public PageSettings PageSettings { get; set; }
    public PatientFilters PatientFilters { get; set; }
}