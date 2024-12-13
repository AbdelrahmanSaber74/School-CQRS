namespace School.Api.MiddleWare
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            var responseModel = new Response<string> { Succeeded = false };

            switch (ex)
            {
                case ValidationException validationEx:
                    // Handle validation exception
                    responseModel.Message = "Validation error.";
                    responseModel.Errors = validationEx.Errors.Select(e => e.ErrorMessage).ToList();
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case UnauthorizedAccessException unauthorizedEx:
                    // Handle unauthorized access
                    _logger.LogWarning(unauthorizedEx, "Unauthorized access attempt.");
                    responseModel.Message = "Unauthorized access.";
                    responseModel.Errors = new List<string> { unauthorizedEx.Message };
                    responseModel.StatusCode = HttpStatusCode.Unauthorized;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case NotFoundException notFoundEx:
                    // Handle not found exception
                    _logger.LogWarning(notFoundEx, "Resource not found.");
                    responseModel.Message = "Resource not found.";
                    responseModel.Errors = new List<string> { notFoundEx.Message };
                    responseModel.StatusCode = HttpStatusCode.NotFound;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case Exception generalEx:
                    // Handle general unexpected exceptions
                    _logger.LogError(generalEx, "An unexpected error occurred.");
                    responseModel.Message = "An unexpected error occurred.";
                    responseModel.Errors = new List<string> { generalEx.Message };
                    responseModel.StatusCode = HttpStatusCode.InternalServerError;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

                default:
                    // Handle unknown errors
                    responseModel.Message = "An unknown error occurred.";
                    responseModel.Errors = new List<string> { ex.Message };
                    responseModel.StatusCode = HttpStatusCode.InternalServerError;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(responseModel);
            await httpContext.Response.WriteAsync(result);
        }
    }

    // Custom NotFoundException (if not already defined)
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
