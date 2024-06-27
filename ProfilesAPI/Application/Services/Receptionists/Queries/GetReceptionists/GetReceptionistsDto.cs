using Domain.Entities;

namespace Application.Common.Dtos.ReceptionistDtos;

public record GetReceptionistsDto(IReadOnlyCollection<GetReceptionistProfileDto> Receptionists)
{
    public static GetReceptionistsDto MapFromReceptionist(IReadOnlyCollection<Receptionist> receptionists)
    {
        return new GetReceptionistsDto(
            receptionists.Select(GetReceptionistProfileDto.MapFromReceptionist).ToList().AsReadOnly());
    }
}