using DAL.Entities;

namespace BAL.Common.Dtos.PhotoDtos;

public record DeleteDocumentDto(Guid IdLinked, DocumentTypeEnum Type);