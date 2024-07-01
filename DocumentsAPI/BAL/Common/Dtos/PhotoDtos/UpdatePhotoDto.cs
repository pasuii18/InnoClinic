using DAL.Entities;

namespace BAL.Common.Dtos.PhotoDtos;

public record UpdatePhotoDto(Guid IdLinked, byte[] Data, PhotoTypeEnum Type);