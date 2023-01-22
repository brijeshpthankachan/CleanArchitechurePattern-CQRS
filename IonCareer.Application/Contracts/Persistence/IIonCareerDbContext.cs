using IonCareer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IonCareer.Application.Contracts.Persistence;

public interface IIonCareerDbContext
{
    DbSet<WeatherData>? WeatherDatas { get; set; }
    DbSet<Role> Roles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}