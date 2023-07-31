using System.Reflection;
using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Common.Behaviours;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); 
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
        return services;
    }
}
