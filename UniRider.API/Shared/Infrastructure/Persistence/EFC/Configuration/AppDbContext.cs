using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Aggregates;

namespace UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration
        // Payments Context Configuration
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Payment>().OwnsOne(p => p.Cardnumber,
            cn =>
            {
                cn.WithOwner().HasForeignKey("id");
                cn.Property(p => p.Value).HasColumnName("CardNumber").IsRequired().HasMaxLength(16);
            });

        builder.Entity<Payment>().OwnsOne(p => p.Cardverification,
            cv =>
            {
                cv.WithOwner().HasForeignKey("id");
                cv.Property(p => p.Value).HasColumnName("CVV").IsRequired().HasMaxLength(3);
            });

        builder.Entity<Payment>().OwnsOne(p => p.Expirationdate,
            ed =>
            {
                ed.WithOwner().HasForeignKey("id");
                ed.Property(p => p.Value).HasColumnName("ExpirationDate").IsRequired();
            });
        // IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}