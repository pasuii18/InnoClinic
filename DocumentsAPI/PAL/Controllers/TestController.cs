using BAL.Common.ServicesInterfaces;
using DAL.Events.ResultEvents;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
public class TestController(IPublishEndpoint _publishEndpoint) : CustomControllerBase
{
    public Guid Id = Guid.Parse("1BB9EDAE-98C6-45DC-A579-7B05CF4AE6E6");
    
    [HttpPost]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var data = PdfGenerator.GeneratePdf(new { Id = Guid.NewGuid(), Name = "Ihar", Surname = "Zinkevich" });
        await _publishEndpoint.Publish(new CreatedResultEvent{ IdResult = Id, Data = data }, cancellationToken);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Update(CancellationToken cancellationToken)
    {
        var data = PdfGenerator.GeneratePdf(new { Id = Guid.NewGuid(), Name = "Matvey", Surname = "Ivanov" });
        await _publishEndpoint.Publish(new UpdatedResultEvent{ IdResult = Id, Data = data }, cancellationToken);
        return Ok();
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(new DeletedResultEvent{ IdResult = Id }, cancellationToken);
        return Ok();
    }
}