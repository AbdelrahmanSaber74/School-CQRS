namespace School.Service.Abstracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<bool> IsEmailUnique(string email);
        Task<bool> IsPhoneNumberUnique(string phoneNumber);
    }
}
