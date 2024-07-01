using Azure.Storage.Blobs.Models;
using BAL.Common.ServicesInterfaces;
using DAL;
using DAL.Common.Contexts;
using DAL.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DocumentController(IDocumentDbService _documentDbService, AzureBlobContext context) : CustomControllerBase
{
    [HttpGet("{idResult}")]
    public async Task<IActionResult> GetDocumentByIdResult(Guid idResult, DocumentTypeEnum type,
        CancellationToken cancellationToken)
    {
        return Result(await _documentDbService.GetDocumentUrlByResultId(idResult, type, cancellationToken));
    }
    
    [HttpGet("all")]
    public async Task GetAll(CancellationToken cancellationToken)
    {
        await foreach (BlobItem blobItem in context.DocumentsContainerClient
                           .GetBlobsAsync(cancellationToken: cancellationToken))
        {
            Console.WriteLine("\t" + blobItem.Name);
        }
    }
}