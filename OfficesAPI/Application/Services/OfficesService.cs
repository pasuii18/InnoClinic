using Application.Common;
using Application.Common.Dtos.OfficesDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServicesInterfaces;
using Domain.Entities;
using MongoDB.Driver;

namespace Application.Services;

public class OfficesService(IOfficesRepo _officesRepo) : IOfficesService
{
    public async Task<IReadOnlyCollection<OfficeReadDto>> GetAllOffices(PageSettings pageSettings, CancellationToken cancellationToken)
    {
        var offices = await _officesRepo.GetAllOffices(pageSettings, cancellationToken);
        var officeReadDtos = offices.Select(OfficeReadDto.MapFromOffice).ToList();
        return officeReadDtos;
    }

    public async Task<OfficeReadDto> GetOfficeInfo(Guid idOffice, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(idOffice, cancellationToken);
        
        if (office == null) throw new KeyNotFoundException("Office not found");

        return OfficeReadDto.MapFromOffice(office);
    }

    public async Task<bool> ChangeOfficeStatus(Guid idOffice, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(idOffice, cancellationToken);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        
        var filter = Builders<Office>.Filter.Eq(o => o.IdOffice, idOffice);
        var update = Builders<Office>.Update
            .Set(o => o.IsActive, !office.IsActive);
        
        await _officesRepo.UpdateOffice(filter, update, cancellationToken);

        return !office.IsActive;
    }

    public Task<Guid> CreateOffice(OfficeCreateDto office, CancellationToken cancellationToken)
    {
        var newOffice = OfficeCreateDto.MapInOffice(office);
        _officesRepo.CreateOffice(newOffice, cancellationToken);
        return Task.FromResult(newOffice.IdOffice);
    }
    
    public async Task UpdateOffice(OfficeUpdateDto officeUpdateDto, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(officeUpdateDto.IdOffice, cancellationToken);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        
        var filter = Builders<Office>.Filter.Eq(o => o.IdOffice, officeUpdateDto.IdOffice);
        var update = Builders<Office>.Update
            .Set(o => o.Address, officeUpdateDto.Address)
            .Set(o => o.RegistryPhoneNumber, officeUpdateDto.RegistryPhoneNumber)
            .Set(o => o.IsActive, officeUpdateDto.IsActive)
            .Set(o => o.IdPhoto, officeUpdateDto.IdPhoto);
        
        await _officesRepo.UpdateOffice(filter, update, cancellationToken);
    }

    public async Task DeleteOffice(Guid idOffice, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(idOffice, cancellationToken);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        
        await _officesRepo.DeleteOffice(idOffice, cancellationToken);
    }
}