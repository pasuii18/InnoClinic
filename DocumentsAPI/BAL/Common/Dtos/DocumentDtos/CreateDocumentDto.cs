using DAL.Entities;

namespace BAL.Common.Dtos.PhotoDtos;

public record CreateDocumentDto(Guid IdLinked, byte[] Data, DocumentTypeEnum Type);