using Application.Common.Dtos.ServiceCategoryDtos;
using Application.Common.Dtos.SpecializationDtos;

namespace Application.Common.Dtos.ServiceDtos;

public record ServiceExtendedReadDto(Guid IdService, string ServiceName, decimal Price, bool IsActive,
    ServiceCategoryReadDto ServiceCategory);