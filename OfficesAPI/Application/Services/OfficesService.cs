using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.OfficesDtos;
using Application.Interfaces;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServicesInterfaces;
using Domain.Entities;
using MongoDB.Driver;

namespace Application.Services;

public class OfficesService(IOfficesRepo _officesRepo) : IOfficesService
{
    public async Task<ICustomResult> GetAllOffices(PageSettings pageSettings, CancellationToken cancellationToken)
    {
        var offices = await _officesRepo.GetAllOffices(pageSettings, cancellationToken);
        var officeReadDtos = offices.Select(OfficeReadDto.MapFromOffice).ToList();
        return new CustomResult(true, Messages.Success, (int)HttpStatusCode.OK, officeReadDtos);
    }

    public async Task<ICustomResult> GetOfficeInfo(Guid idOffice, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(idOffice, cancellationToken);
        if (office == null) return new CustomResult(false, Messages.OfficeNotFound, (int)HttpStatusCode.NotFound);

        var officeDto = OfficeReadDto.MapFromOffice(office);
        return new CustomResult(true, Messages.Success, (int)HttpStatusCode.OK, officeDto);
    }

    public async Task<ICustomResult> ChangeOfficeStatus(Guid idOffice, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(idOffice, cancellationToken);
        if (office == null) return new CustomResult(false, Messages.OfficeNotFound, (int)HttpStatusCode.NotFound);
        
        var filter = Builders<Office>.Filter.Eq(o => o.IdOffice, idOffice);
        var update = Builders<Office>.Update
            .Set(o => o.IsActive, !office.IsActive);
        
        await _officesRepo.UpdateOffice(filter, update, cancellationToken);
        
        return new CustomResult(true, Messages.OfficeStatusUpdatedSuccess, 
            (int)HttpStatusCode.Created, !office.IsActive);
    }

    public async Task<ICustomResult> CreateOffice(OfficeCreateDto office, CancellationToken cancellationToken)
    {
        var newOffice = OfficeCreateDto.MapInOffice(office);
        _officesRepo.CreateOffice(newOffice, cancellationToken);
        return new CustomResult(true, Messages.OfficeCreatedSuccess, (int)HttpStatusCode.Created, newOffice.IdOffice);
    }
    
    public async Task<ICustomResult> UpdateOffice(OfficeUpdateDto officeUpdateDto, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(officeUpdateDto.IdOffice, cancellationToken);
        if (office == null) return new CustomResult(false, Messages.OfficeNotFound, (int)HttpStatusCode.NotFound);
        
        var filter = Builders<Office>.Filter.Eq(o => o.IdOffice, officeUpdateDto.IdOffice);
        var update = Builders<Office>.Update
            .Set(o => o.Address, officeUpdateDto.Address)
            .Set(o => o.RegistryPhoneNumber, officeUpdateDto.RegistryPhoneNumber)
            .Set(o => o.IsActive, officeUpdateDto.IsActive)
            .Set(o => o.IdPhoto, officeUpdateDto.IdPhoto);
        
        await _officesRepo.UpdateOffice(filter, update, cancellationToken);
        
        return new CustomResult(true, Messages.OfficeUpdatedSuccess, (int)HttpStatusCode.Created);
    }

    public async Task<ICustomResult> DeleteOffice(Guid idOffice, CancellationToken cancellationToken)
    {
        var office = await _officesRepo.GetOfficeById(idOffice, cancellationToken);
        if (office == null) return new CustomResult(false, Messages.OfficeNotFound, (int)HttpStatusCode.NotFound);
        
        await _officesRepo.DeleteOffice(idOffice, cancellationToken);
        
        return new CustomResult(true, Messages.OfficeDeletedSuccess, (int)HttpStatusCode.OK);
    }
}