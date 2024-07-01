using DAL.Entities;

namespace BAL.Common.Dtos.PhotoDtos;

public record DeletePhotoDto(Guid IdLinked, PhotoTypeEnum Type);