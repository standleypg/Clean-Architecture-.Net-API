using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
       HttpContext.Items[HttpContextItemKeys.Errors] =errors; 
        var firstError = errors.First();

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
