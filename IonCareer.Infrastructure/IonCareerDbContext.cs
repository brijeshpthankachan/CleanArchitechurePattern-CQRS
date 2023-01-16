using IonCareer.Application.Contracts.Persistence;
using IonCareer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Infrastructure
{
    public class IonCareerDbContext : DbContext, IIonCareerDbContext
    {


        public IonCareerDbContext(DbContextOptions<IonCareerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IonCareerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<WeatherData> WeatherDatas { get; set; }


    }

}