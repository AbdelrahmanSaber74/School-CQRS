using System.Net;
using School.Core.Basics;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the result returned by the mediator and converts it to an appropriate HTTP response.
    /// </summary>
    protected ActionResult HandleResult<T>(Response<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => Ok(result), // 200 OK
            HttpStatusCode.UnprocessableEntity => UnprocessableEntity(result), // 422 Unprocessable Entity
            HttpStatusCode.BadRequest => BadRequest(result), // 400 Bad Request
            HttpStatusCode.NotFound => NotFound(result), // 404 Not Found
            HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, result), // 500 Internal Server Error
            _ => StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred.") // Default response
        };
    }
}
