using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using UniRider.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using UniRider.API.Record.Domain.Model.Aggregates;
using UniRider.API.Payments.Domain.Model.Aggregates;
using UniRider.API.Profile.Domain.Model.Aggregates;

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
        
        // Profile Context Configuration
        
        builder.Entity<VehicleInsurance>().HasKey(insurance => insurance.Id);
        builder.Entity<VehicleInsurance>().Property(insurance => insurance.Id).ValueGeneratedOnAdd();
        builder.Entity<VehicleInsurance>().Property(insurance => insurance.PolicyNumber).IsRequired().HasMaxLength(25);
        builder.Entity<VehicleInsurance>().Property(insurance => insurance.Insurer).IsRequired().HasMaxLength(25);
        builder.Entity<VehicleInsurance>().Property(insurance => insurance.StartDate).IsRequired();
        builder.Entity<VehicleInsurance>().Property(insurance => insurance.ExpirationDate).IsRequired();
        
        builder.Entity<DriverLicense>().HasKey(license => license.Id);
        builder.Entity<DriverLicense>().Property(license => license.Id).ValueGeneratedOnAdd();
        builder.Entity<DriverLicense>().Property(license => license.Type).IsRequired().HasMaxLength(20);
        builder.Entity<DriverLicense>().Property(license => license.Number).IsRequired().HasMaxLength(20);
        builder.Entity<DriverLicense>().Property(license => license.ExpeditionDate).IsRequired();
        builder.Entity<DriverLicense>().Property(license => license.ExpirationDate).IsRequired();
        
        builder.Entity<VehicleDocument>().HasKey(document => document.Id);
        builder.Entity<VehicleDocument>().Property(document => document.Id).ValueGeneratedOnAdd();
        builder.Entity<VehicleDocument>().Property(document => document.Brand).IsRequired().HasMaxLength(25);
        builder.Entity<VehicleDocument>().Property(document => document.Model).IsRequired().HasMaxLength(25);
        builder.Entity<VehicleDocument>().Property(document => document.Color).IsRequired().HasMaxLength(25);
        builder.Entity<VehicleDocument>().Property(document => document.Plate).IsRequired().HasMaxLength(25);
        
        //relationships from the context Profile
        
        builder.Entity<VehicleDocument>()
            .HasOne(document => document.VehicleInsurance)
            .WithMany(insurance => insurance.VehicleDocument)
            .HasForeignKey(document => document.VehicleInsuranceId);
        
        builder.Entity<VehicleDocument>()
            .HasOne(document => document.DriverLicense)
            .WithMany(license => license.VehicleDocument)
            .HasForeignKey(document => document.DriverLicenseId);
        
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