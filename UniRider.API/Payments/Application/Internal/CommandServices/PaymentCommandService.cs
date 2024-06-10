﻿using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Commands;
using UniRider.API.Payments.Domain.Repositories;
using UniRider.API.Payments.Domain.Services;
using UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Payments.Application.Internal.CommandServices;

public class PaymentCommandService: IPaymentCommandService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payment(command);
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return payment;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the payment: {e.Message}");
            return null;
        }
    }
}