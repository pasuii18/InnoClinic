using DAL.Entities;

namespace BAL.Common.Dtos.PhotoDtos;

public record UpdateDocumentDto(Guid IdLinked, byte[] Data, DocumentTypeEnum Type);