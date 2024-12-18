namespace School.Core.Basics
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ResponseHandler(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }

        public Response<T> Deleted<T>()
        {
            return CreateResponse<T>(HttpStatusCode.OK, true, _localizer[ResourceKeys.DeletedSuccessfully]);
        }

        public Response<T> Success<T>(T entity, object meta = null)
        {
            return CreateResponse(HttpStatusCode.OK, true, _localizer[ResourceKeys.OperationCompletedSuccessfully], entity, meta);
        }

        public Response<T> Unauthorized<T>()
        {
            return CreateResponse<T>(HttpStatusCode.Unauthorized, false, _localizer[ResourceKeys.Unauthorized]);
        }

        public Response<T> UnprocessableEntity<T>(string? message = null)
        {
            return CreateResponse<T>(HttpStatusCode.UnprocessableEntity, false, message ?? _localizer[ResourceKeys.UnprocessableEntity]);
        }

        public Response<T> BadRequest<T>(string message = null)
        {
            return CreateResponse<T>(HttpStatusCode.BadRequest, false, message ?? _localizer[ResourceKeys.BadRequest]);
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return CreateResponse<T>(HttpStatusCode.NotFound, false, message ?? _localizer[ResourceKeys.NotFound]);
        }

        public Response<T> Created<T>(T entity, object meta = null)
        {
            return CreateResponse(HttpStatusCode.Created, true, _localizer[ResourceKeys.CreatedSuccessfully], entity, meta);
        }

        private Response<T> CreateResponse<T>(HttpStatusCode statusCode, bool succeeded, string message, T data = default, object meta = null)
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                Succeeded = succeeded,
                Message = message,
                Data = data,
                Meta = meta
            };
        }
    }
}