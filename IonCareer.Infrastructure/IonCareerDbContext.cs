using IonCareer.Application.Contracts.Persistence;
using IonCareer.Domain.Entities;
using IonCareer.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Infrastructure;

public class IonCareerDbContext : DbContext, IIonCareerDbContext
{
    public IonCareerDbContext(DbContextOptions<IonCareerDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherData>? WeatherDatas { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IonCareerDbContext).Assembly);

        IonCareerDataSeeder.SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}