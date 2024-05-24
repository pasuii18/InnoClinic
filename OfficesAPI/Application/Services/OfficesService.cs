using System.Data;
using Application.Common.Interfaces.RepositoryInterfaces;
using Domain.Common.Dtos.OfficesDtos;
using Domain.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MongoDB.Driver;

namespace Application.Services;

public class OfficesService(IOfficesRepo _officesRepo) : IOfficesService
{
    public async Task<List<OfficeReadDto>> GetAllOffices()
    {
        var offices = await _officesRepo.GetAllOffices();
        return offices.Adapt<List<OfficeReadDto>>();
    }

    public async Task<OfficeReadDto> GetOfficeInfo(Guid idOffice)
    {
        var office = await _officesRepo.GetOfficeById(idOffice);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        
        return office.Adapt<OfficeReadDto>();
    }

    public async Task ChangeOfficeStatus(Guid idOffice, OfficeStatusUpdateDto officeStatusUpdateDto)
    {
        var office = await _officesRepo.GetOfficeById(idOffice);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        if (office.IsActive == officeStatusUpdateDto.IsActive) throw new DuplicateNameException("Office is already in this status");
        
        var filter = Builders<Office>.Filter.Eq(o => o.IdOffice, idOffice);
        var update = Builders<Office>.Update
            .Set(o => o.IsActive, officeStatusUpdateDto.IsActive);
        
        await _officesRepo.UpdateOffice(filter, update);
    }

    public async Task<Guid> CreateOffice(OfficeCreateDto office)
    {
        var newOffice = office.Adapt<Office>();
        newOffice.IdOffice = Guid.NewGuid();
        await _officesRepo.CreateOffice(newOffice);
        return newOffice.IdOffice;
    }
    
    public async Task UpdateOffice(Guid idOffice, OfficeUpdateDto officeUpdateDto)
    {
        var office = await _officesRepo.GetOfficeById(idOffice);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        
        var filter = Builders<Office>.Filter.Eq(o => o.IdOffice, idOffice);
        var update = Builders<Office>.Update
            .Set(o => o.Address, officeUpdateDto.Address)
            .Set(o => o.RegistryPhoneNumber, officeUpdateDto.RegistryPhoneNumber)
            .Set(o => o.IsActive, officeUpdateDto.IsActive)
            .Set(o => o.IdPhoto, officeUpdateDto.IdPhoto);
        
        await _officesRepo.UpdateOffice(filter, update);
    }

    public async Task DeleteOffice(Guid idOffice)
    {
        var office = await _officesRepo.GetOfficeById(idOffice);
        
        if (office == null) throw new KeyNotFoundException("Office not found");
        
        await _officesRepo.DeleteOffice(idOffice);
    }
}