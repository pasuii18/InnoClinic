using Application.Common.Dtos.ServiceCategoryDtos;

namespace Application.Common.Dtos.ServiceDtos;

public record ServiceReadDto(Guid IdService, string ServiceName, decimal Price,
    ServiceCategoryReadDto ServiceCategory, bool Status);