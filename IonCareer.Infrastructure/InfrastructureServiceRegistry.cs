using IonCareer.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IonCareer.Infrastructure;

/// <summary>
///     Class that registers all interfaces and implementations to DI
/// </summary>
public static class InfrastructureServiceRegistry
{
    /// <summary>
    ///     Adds the infrastructure services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        AddSqlServer(services, configuration);

        services.AddScoped<IIonCareerDbContext>(provider => provider.GetService<IonCareerDbContext>()!);
    }


    /// <summary>
    ///     Adds Configurations for SQlServer To di
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    private static void AddSqlServer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IonCareerDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("SQLServer"));
        });
    }

    /// <summary>
    ///     Adds  Configurations  for Mysql or Mariadb  to Di
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    internal static void AddMysqlServer(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkMySql().AddDbContext<IonCareerDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("MariaDb"),
                new MySqlServerVersion(new Version()),
                mySqlDbContextOptionsBuilder => mySqlDbContextOptionsBuilder.EnableRetryOnFailure(
                    3,
                    TimeSpan.FromSeconds(30),
                    null)
            ));
    }

    /// <summary>
    ///     Adds  Configurations for Postgres Server  to Di
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    internal static void AddPostgres(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkNpgsql().AddDbContext<IonCareerDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgress")));
    }
}