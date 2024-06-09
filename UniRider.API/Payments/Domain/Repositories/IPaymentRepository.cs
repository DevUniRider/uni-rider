using  UniRider.API.Payments.Domain.Model.Aggregates;
using  UniRider.API.Shared.Domain.Repositories;

namespace UniRider.API.Payments.Domain.Repositories;

public interface IPaymentRepository: IBaseRepository<Payment>
{
    Task AddAsync(Payment payment);
    Task<Payment?> FindByIdAsync(int id);
    Task<IEnumerable<Payment>> ListAsync();
}

