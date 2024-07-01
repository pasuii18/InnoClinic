using BAL.Common.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
public class PhotoController(IPhotoDbService _photoDbService) : CustomControllerBase
{
    [HttpGet("{idPhoto}")]
    public async Task<IActionResult> GetPhotoById(Guid idPhoto, CancellationToken cancellationToken)
    {   
        return Result(await _photoDbService.GetPhotoUrlById(idPhoto, cancellationToken));
    }
}