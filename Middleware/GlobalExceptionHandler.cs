using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EventCountdownBackend.Middleware
{

    /*
     * Custom ExceptionHandler serviced that is used by the ExceptionHandler middleware
     * If theres a new Exception implementation in the backend it should be added to the switch statement
     * Any unknown Exception by the Service will be handled as Internal Server Error.
     */

    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {  _logger = logger; }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            // Map exceptions to statusCodes and messages

            _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);
            var (statusCode, title) = exception switch
            {
                KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource Not Found"),

                ArgumentException => (StatusCodes.Status400BadRequest, "Bad Request"),

                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),

                NotImplementedException => (StatusCodes.Status501NotImplemented, "Not ImplementedS"),

                _ => (StatusCodes.Status500InternalServerError, "An unexpected server error occurred.")
            };


            // Create RFC 7807 Problem Details response

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = statusCode == StatusCodes.Status500InternalServerError
                ? "Please contact support if the issue persists."
                : exception.Message,

                // URL that caused the exception
                Instance = httpContext.Request.Path
            };


            // Configure Response

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
