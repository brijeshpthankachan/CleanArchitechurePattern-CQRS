using IonCareer.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IonCareer.Infrastructure
{
    /// <summary>
    /// Class that registers all interfaces and implementations to DI
    /// </summary>
    public static class InfrastructureServiceRegistry
    {
        /// <summary>
        /// Adds the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddInfrastructureServices(this IServiceCollection services,
          IConfiguration configuration)
        {



            //for Mysql or Mariadb
            //    services.AddEntityFrameworkMySql().AddDbContext<IonCareerDbContext>(options =>
            //options.UseMySql(

            //     configuration.GetConnectionString("MariaDb"),
            //      new MySqlServerVersion(new Version()),
            //      options => options.EnableRetryOnFailure(
            //          maxRetryCount: 3,
            //          maxRetryDelay: System.TimeSpan.FromSeconds(30),
            //          errorNumbersToAdd: null)

            //    ));




            //for Postgress 
            //      services.AddEntityFrameworkNpgsql().AddDbContext<IonCareerDbContext>(options =>
            //options.UseNpgsql(configuration.GetConnectionString("Postgress")));



            //for SQLserver
            services.AddDbContext<IonCareerDbContext>(option =>
            {

                option.UseSqlServer(configuration.GetConnectionString("SQLServer"));

            });

            services.AddScoped<IIonCareerDbContext>(provider => provider.GetService<IonCareerDbContext>());
        }
    }
}
