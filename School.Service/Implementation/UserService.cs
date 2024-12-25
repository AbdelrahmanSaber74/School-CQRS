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

        public async Task<bool> IsEmailUnique(string email)
        {
            return !await _userRepository.ExistsAsync(r => r.Email == email);
        }

        public async Task<bool> IsPhoneNumberUnique(string phoneNumber)
        {
            return !await _userRepository.ExistsAsync(r => r.PhoneNumber == phoneNumber);
        }
    }
}
