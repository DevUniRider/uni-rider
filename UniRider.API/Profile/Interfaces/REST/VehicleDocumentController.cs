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
public class VehicleDocumentController(
    IVehicleDocumentCommandService vehicleDocumentCommandService,
    IVehicleDocumentQueryService vehicleDocumentQueryService) 
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVehicleDocument(
        [FromBody] CreateVehicleDocumentResource createVehicleDocumentResource)
    {
        var createVehicleDocumentCommand = 
            CreateVehicleDocumentCommandFromResourceAssembler.ToCommandFromResource(createVehicleDocumentResource);
        var vehicleDocument = await vehicleDocumentCommandService.Handle(createVehicleDocumentCommand);
        if (vehicleDocument is null) return BadRequest();
        var resource = VehicleDocumentResourceFromEntityAssembler.ToResourceFromEntity(vehicleDocument);
        return CreatedAtAction(nameof(GetVehicleDocumentById), new { vehicleDocumentId = resource.Id }, resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicleDocuments()
    {
        var getAllVehicleDocumentsQuery = new GetAllVehicleDocumentsQuery();
        var vehicleDocuments = await vehicleDocumentQueryService.Handle(getAllVehicleDocumentsQuery);
        var resources = vehicleDocuments.Select(VehicleDocumentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{vehicleDocumentId:int}")]
    public async Task<IActionResult> GetVehicleDocumentById(int vehicleDocumentId)
    {
        var vehicleDocument = await vehicleDocumentQueryService.Handle(new GetAllVehicleDocumentByIdQuery(vehicleDocumentId));
        if (vehicleDocument == null) return NotFound();
        var vehicleDocumentResource = VehicleDocumentResourceFromEntityAssembler.ToResourceFromEntity(vehicleDocument);
        return Ok(vehicleDocumentResource);
    }
}