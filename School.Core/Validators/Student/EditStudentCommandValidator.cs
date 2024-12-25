namespace School.Core.Validators.Student
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public EditStudentCommandValidator(IStudentService studentService, IStringLocalizer<SharedResource> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;

            // Validate Name
            RuleFor(x => x.EditStudentDTO.FirstName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
                .MaximumLength(100).WithMessage(_localizer[ResourceKeys.NameMaxLength]);

            RuleFor(x => x.EditStudentDTO.LastName)
           .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
           .MaximumLength(100).WithMessage(_localizer[ResourceKeys.NameMaxLength]);
            // Validate Phone
            RuleFor(x => x.EditStudentDTO.Phone)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.PhoneRequired])
                .Matches(ValidationPatterns.PhoneNumber).WithMessage(_localizer[ResourceKeys.PhoneInvalidFormat]);

            // Validate Email
            RuleFor(x => x.EditStudentDTO.Email)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmailRequired])
                .EmailAddress().WithMessage(_localizer[ResourceKeys.EmailInvalidFormat]);

            // Validate Email uniqueness excluding self
            RuleFor(x => x.EditStudentDTO)
                .MustAsync(async (student, cancellationToken) =>
                    !await _studentService.IsEmailExistExcludeSelf(student.studentId, student.Email))
                .WithMessage(_localizer[ResourceKeys.AlreadyExistsMessage]);

            // Validate Phone uniqueness excluding self
            RuleFor(x => x.EditStudentDTO)
                .MustAsync(async (student, cancellationToken) =>
                    !await _studentService.IsPhoneExistExcludeSelf(student.studentId, student.Phone))
                .WithMessage(_localizer[ResourceKeys.AlreadyExistsMessage]);
        }
    }
}