using System.Net;
using Application.Common;
using Application.Common.Dtos.SpecializationDtos;
using Application.Common.Specifications;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using Application.Interfaces.ServicesInterfaces;
using Domain.Entities;
using Mapster;

namespace Application.Services;

public class SpecializationService(ISpecializationRepo _specializationRepo, IServiceRepo _serviceRepo)
    : ISpecializationService
{
    public async Task<ICustomResult> GetSpecializations(CancellationToken cancellationToken)
    {
        var specializations = await _specializationRepo.GetSpecializations(
            new GetSpecializationsSpecification(), cancellationToken);
        
        var specializationsDtos = specializations.Adapt<IReadOnlyCollection<SpecializationReadDto>>();
        return new CustomResult(true, HttpStatusCode.OK, specializationsDtos);
    }

    public async Task<ICustomResult> GetSpecializationById(Guid idService, CancellationToken cancellationToken)
    {
        var specialization = await _specializationRepo.GetSpecializationById(
            new GetSpecializationByIdSpecification(idService), cancellationToken);
        if(specialization == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.SpecializationNotFound);
        
        var specializationDto = specialization.Adapt<SpecializationExtendedReadDto>();
        return new CustomResult(true, HttpStatusCode.OK, specializationDto);
    }

    public async Task<ICustomResult> CreateSpecialization(SpecializationCreateDto specializationCreateDto, CancellationToken cancellationToken)
    {
        var newSpecialization = specializationCreateDto.Adapt<Specialization>();
        newSpecialization.IdSpecialization = Guid.NewGuid();
        foreach (var idService in specializationCreateDto.IdsService)
        {
            var service = await _serviceRepo.GetServiceById(new GetServiceByIdSpecification(idService), cancellationToken);
            if(service == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceNotFound);
            service.IdSpecialization = newSpecialization.IdSpecialization;
        }
        
        await _specializationRepo.CreateSpecialization(newSpecialization, cancellationToken);
        await _specializationRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK, newSpecialization.IdSpecialization);
    }

    public async Task<ICustomResult> UpdateSpecialization(SpecializationUpdateDto specializationUpdateDto, CancellationToken cancellationToken)
    {
        var specialization = await _specializationRepo.GetSpecializationById(
            new GetSpecializationByIdSpecification(specializationUpdateDto.IdSpecialization), cancellationToken);
        if(specialization == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.SpecializationNotFound);
        
        specializationUpdateDto.Adapt(specialization);
        await _specializationRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> UpdateSpecializationStatus(Guid idService, CancellationToken cancellationToken)
    {
        var specialization = await _specializationRepo.GetSpecializationById(
            new GetSpecializationByIdSpecification(idService), cancellationToken);
        if(specialization == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.SpecializationNotFound);
        
        specialization.IsActive = !specialization.IsActive;
        await _specializationRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> DeleteSpecialization(Guid idService, CancellationToken cancellationToken)
    {
        var specialization = await _specializationRepo.GetSpecializationById(
            new GetSpecializationByIdSpecification(idService), cancellationToken);
        if(specialization == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.SpecializationNotFound);
        
        _specializationRepo.DeleteSpecialization(specialization);
        await _specializationRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
}