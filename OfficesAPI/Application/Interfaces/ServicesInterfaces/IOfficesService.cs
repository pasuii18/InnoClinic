using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.OfficesDtos;

namespace Application.Interfaces.ServicesInterfaces;

public interface IOfficesService
{
    public Task<ICustomResult> GetAllOffices(PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<ICustomResult> GetOfficeInfo(Guid idOffice, CancellationToken cancellationToken);
    public Task<ICustomResult> ChangeOfficeStatus(Guid idOffice, CancellationToken cancellationToken);
    public Task<ICustomResult> CreateOffice(OfficeCreateDto office, CancellationToken cancellationToken);
    public Task<ICustomResult> UpdateOffice(OfficeUpdateDto office, CancellationToken cancellationToken);
    public Task<ICustomResult> DeleteOffice(Guid idOffice, CancellationToken cancellationToken);
}