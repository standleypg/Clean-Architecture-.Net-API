using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters;

/// <summary>
/// Error handling filter 
/// 
/// in case want to use it, please enable it in Program.cs 
/// </summary>
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        //adding problemDetails to the response
        var problemDetails = new ProblemDetails
        {
            Type= "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request.",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.Message,
            Instance= context.HttpContext.Request.Path
        };

        context.Result = new OkObjectResult(problemDetails);


        context.ExceptionHandled = true;
        // base.OnException(context); 
    }
}