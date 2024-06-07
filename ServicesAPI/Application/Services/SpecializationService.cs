using Application.Common.Dtos.SpecializationDtos;
using Application.Interfaces;
using Application.Interfaces.ServicesInterfaces;

namespace Application.Services;

public class SpecializationService
    : ISpecializationService
{
    public async Task<ICustomResult> GetSpecializations(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> GetSpecializationById(Guid idService, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> CreateSpecialization(SpecializationCreateDto specializationCreateDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> UpdateSpecialization(SpecializationUpdateDto specializationUpdateDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> UpdateSpecializationStatus(Guid idService, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}