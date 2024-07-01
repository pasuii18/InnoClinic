using BAL.Common.ServicesInterfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
public class PhotoController(IPhotoDbService _photoDbService) : CustomControllerBase
{
    [HttpGet("{idPhoto}")]
    public async Task<IActionResult> GetPhotoById(Guid idPhoto, PhotoTypeEnum type, CancellationToken cancellationToken)
    {   
        return Result(await _photoDbService.GetPhotoUrlById(idPhoto, type, cancellationToken));
    }
}