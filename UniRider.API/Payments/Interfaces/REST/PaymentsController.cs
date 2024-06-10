using System.Net.Mime;
using UniRider.API.Payments.Domain.Model.Commands;
using UniRider.API.Payments.Domain.Model.Queries;
using UniRider.API.Payments.Domain.Services;
using UniRider.API.Payments.Interfaces.REST.Resources;
using UniRider.API.Payments.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;


namespace UniRider.API.Payments.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentsController(IPaymentCommandService paymentCommandService, IPaymentQueryService paymentQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePayment(CreatePaymentResource resource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest();
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return CreatedAtAction(nameof(GetPaymentById), new {paymentId = paymentResource.Id}, paymentResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await paymentQueryService.Handle(new GetAllPaymentsQuery());
        var paymentResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }

    [HttpGet("{paymentId:int}")]
    public async Task<IActionResult> GetPaymentById(int paymentId)
    {
        var payment = await paymentQueryService.Handle(new GetPaymentByIdQuery(paymentId));
        if (payment == null) return NotFound();
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }
}