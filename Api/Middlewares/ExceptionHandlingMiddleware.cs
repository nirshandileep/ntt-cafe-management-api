using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using ValidationException = FluentValidation.ValidationException;

namespace NTT.CafeManagement.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ProblemDetailsFactory problemDetailsFactory)
{
    private readonly RequestDelegate _next = next;
    private readonly ProblemDetailsFactory _problemDetailsFactory = problemDetailsFactory;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = _problemDetailsFactory.CreateProblemDetails(
            context,
            statusCode: StatusCodes.Status500InternalServerError,
            title: "An error occurred while processing your request.",
            detail: exception.Message);

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/problem+json";

        return context.Response.WriteAsJsonAsync(problemDetails);
    }

    private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        var problemDetails = _problemDetailsFactory.CreateProblemDetails(
                context,
                statusCode: StatusCodes.Status400BadRequest,
                title: "Validation error",
                detail: "One or more validation errors occurred.");

        problemDetails.Extensions["errors"] = exception.Errors
           .Select(e => e.ErrorMessage)
           .ToList();

        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/problem+json";

        return context.Response.WriteAsJsonAsync(problemDetails);
    }
}
