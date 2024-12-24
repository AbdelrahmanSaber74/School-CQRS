namespace School.Service.Abstracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
    }
}
