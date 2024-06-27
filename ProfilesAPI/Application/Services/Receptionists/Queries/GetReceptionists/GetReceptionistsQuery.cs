using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;

public class GetReceptionistsQuery : IRequest<ICustomResult>
{
    public PageSettings PageSettings { get; set; }
    public ReceptionistFilters ReceptionistFilters { get; set; }
}