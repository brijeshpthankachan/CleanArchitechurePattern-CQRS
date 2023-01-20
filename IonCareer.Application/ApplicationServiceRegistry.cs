//using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IonCareer.Application
{

    /// <summary>
    /// Class that registers all interfaces and implementations to DI
    /// </summary>
    public static class ApplicationServiceRegistry
    {
        /// <summary>
        /// Adds the Application services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

            //services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}