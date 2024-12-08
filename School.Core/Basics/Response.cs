namespace School.Core.Basics;
public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
    public object Meta { get; set; }

    public Response()
    {
        Errors = new List<string>();
    }

    public Response(T data, string message = null)
    {
        Succeeded = true;
        Data = data;
        Message = message;
        StatusCode = System.Net.HttpStatusCode.OK;
        Errors = new List<string>();
    }

    public Response(string message)
    {
        Succeeded = false;
        Message = message;
        StatusCode = System.Net.HttpStatusCode.BadRequest;
        Errors = new List<string>();
    }
}   

