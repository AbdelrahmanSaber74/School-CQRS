namespace School.Service.Abstracts
{
    public interface IAuthenticationService
    {
        Task<string> Create(ApplicationUser user);

    }
}
