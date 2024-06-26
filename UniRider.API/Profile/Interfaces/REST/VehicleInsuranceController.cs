using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using UniRider.API.Profile.Domain.Model.Queries;
using UniRider.API.Profile.Domain.Services;
using UniRider.API.Profile.Interfaces.REST.Resources;
using UniRider.API.Profile.Interfaces.REST.Transform;

namespace UniRider.API.Profile.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class VehicleInsuranceController(
    IVehicleInsuranceCommandService vehicleInsuranceCommandService, 
    IVehicleInsuranceQueryService vehicleInsuranceQueryService) 
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVehicleInsurance(
        [FromBody] CreateVehicleInsuranceResource createVehicleInsuranceResource)
    {
        var createVehicleInsuranceCommand = 
            CreateVehicleInsuranceCommandFromResourceAssembler.ToCommandFromResource(createVehicleInsuranceResource);
        var vehicleInsurance = await vehicleInsuranceCommandService.Handle(createVehicleInsuranceCommand);
        if (vehicleInsurance is null) return BadRequest();
        var resource = VehicleInsuranceResourceFromEntityAssembler.ToResourceFromEntity(vehicleInsurance);
        return CreatedAtAction(nameof(GetVehicleInsuranceById), new { vehicleInsuranceId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicleInsurances()
    {
        var getAllVehicleInsurancesQuery = new GetAllVehicleInsurancesQuery();
        var vehicleInsurances = await vehicleInsuranceQueryService.Handle(getAllVehicleInsurancesQuery);
        var resources = vehicleInsurances.Select(VehicleInsuranceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{vehicleInsuranceId:int}")]
    public async Task<IActionResult> GetVehicleInsuranceById(int vehicleInsuranceId)
    {
        var vehicleInsurance = await vehicleInsuranceQueryService.Handle(new GetAllVehicleInsuranceByIdQuery(vehicleInsuranceId));
        if (vehicleInsurance == null) return NotFound();
        var vehicleInsuranceResource = VehicleInsuranceResourceFromEntityAssembler.ToResourceFromEntity(vehicleInsurance);
        return Ok(vehicleInsuranceResource);
    }
}