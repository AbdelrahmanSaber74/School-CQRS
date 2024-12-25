namespace School.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<string> Create(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var result = await _userManager.CreateAsync(user, user.PasswordHash!);

            if (result.Succeeded)
            {
                return ResponseMessages.SuccessMessage;
            }

            // Handling errors if user creation fails
            var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
            return $"Failed to create user: {errorMessage}";
        }
    }
}
