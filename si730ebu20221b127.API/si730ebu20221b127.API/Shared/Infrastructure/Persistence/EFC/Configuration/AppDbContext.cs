
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
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
        
        // Personnel Context
        builder.Entity<Examiner>().HasKey(e => e.Id);
        builder.Entity<Examiner>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Examiner>().OwnsOne(e => e.FirstName,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.firstName).IsRequired().HasMaxLength(50);
            });
        builder.Entity<Examiner>().OwnsOne(e => e.LastName,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.lastName).IsRequired().HasMaxLength(50);
            });
        builder.Entity<Examiner>().OwnsOne(e => e.NationalProviderIdentifier,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.nationalProviderIdentifier).IsRequired().HasMaxLength(30);
            });
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}