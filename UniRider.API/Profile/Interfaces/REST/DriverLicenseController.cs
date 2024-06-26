    using System.Net.Mime;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using UniRider.API.Profile.Domain.Model.Queries;
    using UniRider.API.Profile.Domain.Services;
    using UniRider.API.Profile.Interfaces.REST.Resources;
    using UniRider.API.Profile.Interfaces.REST.Transform;

    namespace UniRider.API.Profile.Interfaces.REST;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class DriverLicenseController(
        IDriverLicenseCommandService driverLicenseCommandService,
        IDriverLicenseQueryService driverLicenseQueryService) : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Crates a driver license",
            Description = "Creates a driver license for a user",
            OperationId = "CreateDriverLicense")]
        [SwaggerResponse(201, "Driver license created", typeof(DriverLicenseResource))]
        public async Task<IActionResult> CreateDriverLicense(
            [FromBody] CreateDriverLicenseResource createDriverLicenseResource)
        {
            var createDriverLicenseCommand =
                CreateDriverLicenseCommandFromResourceAssembler.ToCommandFromResource(createDriverLicenseResource);
            var driverLicense = await driverLicenseCommandService.Handle(createDriverLicenseCommand);
            if (driverLicense is null) return BadRequest();
            var resource = DriverLicenseResourceFromEntityAssembler.ToResourceFromEntity(driverLicense);
            return CreatedAtAction(nameof(GetDriverLicenseById), new { driverLicenseId = resource.Id }, resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDriverLicenses()
        {
            var getAllDriverLicensesQuery = new GetAllDriverLicensesQuery();
            var driverLicenses = await driverLicenseQueryService.Handle(getAllDriverLicensesQuery);
            var resources = driverLicenses.Select(DriverLicenseResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("{driverLicenseId:int}")]
        public async Task<IActionResult> GetDriverLicenseById(int driverLicenseId)
        {
            var driverLicense = await driverLicenseQueryService.Handle(new GetAllDriverLicenseByIdQuery(driverLicenseId));
            if (driverLicense == null) return NotFound();
            var driverLicenseResource = DriverLicenseResourceFromEntityAssembler.ToResourceFromEntity(driverLicense);
            return Ok(driverLicenseResource);
        }
    }