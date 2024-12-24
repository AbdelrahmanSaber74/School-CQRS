namespace School.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            var query = _userRepository.GetTableAsTracking();
            var user = await query.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }


    }
}
