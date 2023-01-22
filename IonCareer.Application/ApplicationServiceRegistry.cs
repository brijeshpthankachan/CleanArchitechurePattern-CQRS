//using FluentValidation;

using System.Reflection;
using FluentValidation;
using IonCareer.Application.Configurations;
using IonCareer.Application.MiddleWare;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IonCareer.Application;

/// <summary>
///     Class that registers all interfaces and implementations to DI
/// </summary>
public static class ApplicationServiceRegistry
{
    /// <summary>
    ///     Adds the Application services.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}