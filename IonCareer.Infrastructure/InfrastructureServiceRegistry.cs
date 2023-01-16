using IonCareer.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IonCareer.Infrastructure
{
    public static class InfrastructureServiceRegistry
    {
        public static void AddInfrastructureServices(this IServiceCollection services,
          IConfiguration configuration)
        {


            //for MySql or MariaDb

            //     services.AddEntityFrameworkMySql().AddDbContext<IonCareerDbContext>(options =>
            //options.UseMySql(

            //     configuration.GetConnectionString("MariaDb"),
            //      new MySqlServerVersion(new Version()),
            //      options => options.EnableRetryOnFailure(
            //          maxRetryCount: 3,
            //          maxRetryDelay: System.TimeSpan.FromSeconds(30),
            //          errorNumbersToAdd: null)

            //    ));


            //for SQL Server

            services.AddDbContext<IonCareerDbContext>(option =>
            {

                option.UseSqlServer(configuration.GetConnectionString("SQLServer"));

            });

            services.AddScoped<IIonCareerDbContext>(provider => provider.GetService<IonCareerDbContext>());
        }
    }
}
