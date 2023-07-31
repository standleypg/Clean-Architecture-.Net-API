using API.Common.Errors;
using API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //overiding default problem details factory for customizing problem details
        services.AddSingleton<ProblemDetailsFactory, CleanArchitectureProblemDetailsFactory>();

        services.AddMapping();
        return services;
    }
}
