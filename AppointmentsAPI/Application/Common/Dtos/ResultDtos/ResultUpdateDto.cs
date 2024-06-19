namespace Application.Common.Dtos.ResultDtos;

public record ResultUpdateDto(Guid IdResult, string Complaints, string Conclusion, string Recommendations);