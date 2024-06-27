using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;

public class GetReceptionistProfileQuery : IRequest<ICustomResult>
{
    public Guid IdReceptionist { get; set; }
}