namespace School.Core.Validators.Authentication
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IUserService _userService;

        public CreateUserCommandValidator(IStringLocalizer<SharedResource> localizer, IUserService userService)
        {
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            // First Name Validation
            RuleFor(command => command._createDTO.FirstName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
                .MaximumLength(50).WithMessage(_localizer[ResourceKeys.NameMaxLength]);

            // Last Name Validation
            RuleFor(command => command._createDTO.LastName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.SurnameRequired])
                .MaximumLength(50).WithMessage(_localizer[ResourceKeys.SurnameMaxLength]);

            // UserName Validation
            RuleFor(command => command._createDTO.UserName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
                .MaximumLength(50).WithMessage(_localizer[ResourceKeys.NameMaxLength]);

            // Email Validation
            RuleFor(command => command._createDTO.Email)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmailRequired])
                .EmailAddress().WithMessage(_localizer[ResourceKeys.EmailInvalidFormat])
                .MustAsync(async (email, cancellationToken) => await _userService.IsEmailUnique(email))
                .WithMessage(_localizer[ResourceKeys.EmailAlreadyExists]);

            // Password Validation
            RuleFor(command => command._createDTO.Password)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.PasswordRequired])
                .MinimumLength(6).WithMessage(_localizer[ResourceKeys.PasswordMinLength]);

            // Confirm Password Validation
            RuleFor(command => command._createDTO.ConfirmPassword)
                .Equal(command => command._createDTO.Password).WithMessage(_localizer[ResourceKeys.PasswordsDoNotMatch]);

            // Phone Number Validation
            RuleFor(command => command._createDTO.PhoneNumber)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.PhoneRequired])
                .Matches(ValidationPatterns.PhoneNumber).WithMessage(_localizer[ResourceKeys.PhoneInvalidFormat])
                .MustAsync(async (phoneNumber, cancellationToken) => await _userService.IsPhoneNumberUnique(phoneNumber))
                .WithMessage(_localizer[ResourceKeys.PhoneAlreadyExists]);

            // Address Validation
            RuleFor(command => command._createDTO.Address)
                .MaximumLength(100).WithMessage(_localizer[ResourceKeys.AddressMaxLength]);

            // Country Validation
            RuleFor(command => command._createDTO.Country)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.CountryRequired])
                .MaximumLength(50).WithMessage(_localizer[ResourceKeys.CountryMaxLength]);
        }
    }
}
