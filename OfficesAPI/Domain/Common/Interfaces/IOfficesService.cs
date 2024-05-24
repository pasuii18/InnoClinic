using Domain.Common.Dtos.OfficesDtos;
using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IOfficesService
{
    public Task<List<OfficeReadDto>> GetAllOffices();
    public Task<OfficeReadDto> GetOfficeInfo(Guid idOffice);
    public Task ChangeOfficeStatus(Guid idOffice, OfficeStatusUpdateDto officeStatusUpdateDto);
    public Task<Guid> CreateOffice(OfficeCreateDto office);
    public Task UpdateOffice(Guid idOffice,OfficeUpdateDto office);
    public Task DeleteOffice(Guid idOffice);
}