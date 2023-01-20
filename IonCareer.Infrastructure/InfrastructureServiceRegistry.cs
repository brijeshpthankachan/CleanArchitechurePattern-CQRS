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

            services.AddDbContext<IonCareerDbContext>(option =>
            {

                option.UseSqlServer(configuration.GetConnectionString("SQLServer"));

            });

            services.AddScoped<IIonCareerDbContext>(provider => provider.GetService<IonCareerDbContext>());
        }
    }
}
