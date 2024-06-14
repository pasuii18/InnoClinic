using Application.Common.Dtos.SpecializationDtos;
using Application.Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class SpecializationsController(ISpecializationService _specializationSpecialization) 
    : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSpecializations(CancellationToken cancellationToken)
    {
        var result = await _specializationSpecialization.GetSpecializations(cancellationToken);
        return Result(result);
    }
    
    [HttpGet("{idSpecialization}")]
    public async Task<IActionResult> GetSpecializationById(Guid idSpecialization, CancellationToken cancellationToken)
    { 
        var result = await _specializationSpecialization.GetSpecializationById(idSpecialization, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSpecialization([AutoValidateAlways] SpecializationCreateDto serviceCreateDto,
        CancellationToken cancellationToken)
    {
        var result = await _specializationSpecialization.CreateSpecialization(serviceCreateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateSpecialization([AutoValidateAlways] SpecializationUpdateDto serviceUpdateDto,
        CancellationToken cancellationToken)
    {
        var result = await _specializationSpecialization.UpdateSpecialization(serviceUpdateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("{idSpecialization}")]
    public async Task<IActionResult> UpdateSpecializationStatus(Guid idSpecialization, CancellationToken cancellationToken)
    {
        var result = await _specializationSpecialization.UpdateSpecializationStatus(idSpecialization, cancellationToken);
        return Result(result);
    }
    
    [HttpDelete("{idSpecialization}")]
    public async Task<IActionResult> DeleteSpecialization(Guid idSpecialization, CancellationToken cancellationToken)
    {
        var result = await _specializationSpecialization.DeleteSpecialization(idSpecialization, cancellationToken);
        return Result(result);
    }
}