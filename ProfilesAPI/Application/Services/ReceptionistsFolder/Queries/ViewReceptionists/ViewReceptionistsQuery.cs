using Application.Common.Dtos;
using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;

public class ViewReceptionistsQuery : IRequest<ICustomResult>
{
    public PageSettings PageSettings { get; set; }
}