using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace BookSeller.WebAPI.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Status = httpContext.Response.StatusCode,
                Title = "Server error",
                Detail = exception.Message
            };           

            Log.Error($"\nError Code: {problemDetails.Status.Value}Title: {problemDetails.Title}\nMessage: {problemDetails.Detail}\n");

            return true;
        }
    }
}
