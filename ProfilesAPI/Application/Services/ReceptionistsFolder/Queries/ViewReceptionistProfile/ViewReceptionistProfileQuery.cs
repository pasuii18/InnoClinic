using Application.Interfaces;
using MediatR;

namespace Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;

public class ViewReceptionistProfileQuery : IRequest<ICustomResult>
{
    public Guid IdReceptionist { get; set; }
}