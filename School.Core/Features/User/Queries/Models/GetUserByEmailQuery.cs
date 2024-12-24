namespace School.Core.Features.User.Queries.Models
{
    public class GetUserByEmailQuery : IRequest<Response<UserDTO>>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
