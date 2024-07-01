using DAL.Entities;

namespace BAL.Common.Dtos.PhotoDtos;

public record CreatePhotoDto(Guid IdLinked, byte[] Data, PhotoTypeEnum Type);