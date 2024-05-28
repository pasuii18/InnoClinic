using Application.Common;
using Application.Common.Dtos.OfficesDtos;

namespace Application.Interfaces.ServicesInterfaces;

public interface IOfficesService
{
    public Task<IReadOnlyCollection<OfficeReadDto>> GetAllOffices(PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<OfficeReadDto> GetOfficeInfo(Guid idOffice, CancellationToken cancellationToken);
    public Task<bool> ChangeOfficeStatus(Guid idOffice, CancellationToken cancellationToken);
    public Task<Guid> CreateOffice(OfficeCreateDto office, CancellationToken cancellationToken);
    public Task UpdateOffice(OfficeUpdateDto office, CancellationToken cancellationToken);
    public Task DeleteOffice(Guid idOffice, CancellationToken cancellationToken);
}