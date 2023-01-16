using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IonCareer.Application
{
    public static class ApplicationServiceRegistry
    {
        /// <summary>
        /// Adds the Application services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
