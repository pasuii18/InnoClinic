using Application.Common.Dtos.SpecializationDtos;

namespace Application.Interfaces.ServicesInterfaces;

public interface ISpecializationService
{
    Task<ICustomResult> GetSpecializations(CancellationToken cancellationToken);
    Task<ICustomResult> GetSpecializationById(Guid idService, CancellationToken cancellationToken);
    Task<ICustomResult> CreateSpecialization(SpecializationCreateDto specializationCreateDto, CancellationToken cancellationToken);
    Task<ICustomResult> UpdateSpecialization(SpecializationUpdateDto specializationUpdateDto, CancellationToken cancellationToken);
    Task<ICustomResult> UpdateSpecializationStatus(Guid idService, CancellationToken cancellationToken);
}