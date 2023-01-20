using IonCareer.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace IonCareer.Application.Contracts.Persistence
{
    public interface IIonCareerDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<WeatherData> WeatherDatas { get; set; }
        DbSet<Role> Roles { get; set; }
    }
}
