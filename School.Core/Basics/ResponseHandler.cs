namespace School.Core.Basics;
public class ResponseHandler
{
    public Response<T> Deleted<T>()
    {
        return new Response<T>
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Deleted successfully"
        };
    }

    public Response<T> Success<T>(T entity, object meta = null)
    {
        return new Response<T>
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Operation completed successfully",
            Meta = meta
        };
    }

    public Response<T> Unauthorized<T>()
    {
        return new Response<T>
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = false,
            Message = "Unauthorized"
        };
    }
    public Response<T> UnprocessableEntity<T>(string? message = null)
    {
        return new Response<T>
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = message ?? "UnprocessableEntity"
        };
    }
    public Response<T> BadRequest<T>(string message = null)
    {
        return new Response<T>
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = message ?? "Bad request"
        };
    }

    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message ?? "Not found"
        };
    }

    public Response<T> Created<T>(T entity, object meta = null)
    {
        return new Response<T>
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = "Created successfully",
            Meta = meta
        };
    }
}