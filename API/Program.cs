using API.Common.Errors;
using API.Filters;
using API.Middleware;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Uncomment this if want to use ErrorHandlingFilterAttribute via Exception Filter Attribute
    // builder.Services.AddControllers(options => options.Filters.Add(new ErrorHandlingFilterAttribute()));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // injection services from application and infrastructure
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

    //overiding default problem details factory for customizing problem details
    builder.Services.AddSingleton<ProblemDetailsFactory, CleanArchitectureProblemDetailsFactory>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Uncomment this if want to use ErrorHandlingMiddleware via exception middleware
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    // Error handling via endpoint
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}