using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Repositories;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UniRider.API.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Payment payment)
    {
        await Context.Set<Payment>().AddAsync(payment);
    }

    public async Task<Payment?> FindByIdAsync(int id)
    {
        return await Context.Set<Payment>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await Context.Set<Payment>().ToListAsync();
    }
}
