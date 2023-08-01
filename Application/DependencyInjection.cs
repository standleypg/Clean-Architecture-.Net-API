using System.Reflection;
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); 
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
        return services;
    }
}
