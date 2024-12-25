namespace School.Core.Validators.Student
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AddStudentCommandValidator(
            IStudentService studentService,
            IStringLocalizer<SharedResource> localizer,
            IDepartmentService departmentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            // First Name Validation
            RuleFor(x => x.Student.FirstName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
                .MaximumLength(100).WithMessage(_localizer[ResourceKeys.NameMaxLength]);

            // Last Name Validation
            RuleFor(x => x.Student.LastName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
                .MaximumLength(100).WithMessage(_localizer[ResourceKeys.NameMaxLength]);

            // Phone Validation
            RuleFor(x => x.Student.Phone)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.PhoneRequired])
                .Matches(ValidationPatterns.PhoneNumber).WithMessage(_localizer[ResourceKeys.PhoneInvalidFormat]);

            // Email Validation
            RuleFor(x => x.Student.Email)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmailRequired])
                .EmailAddress().WithMessage(_localizer[ResourceKeys.EmailInvalidFormat]);

            // Date of Birth Validation
            RuleFor(x => x.Student.DateOfBirth)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.DateOfBirthRequired])
                .Must(date => date < DateTime.Today).WithMessage(_localizer[ResourceKeys.DateOfBirthPast]);

            // Enrollment Date Validation
            RuleFor(x => x.Student.EnrollmentDate)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EnrollmentDateRequired])
                .Must(date => date <= DateTime.Today).WithMessage(_localizer[ResourceKeys.EnrollmentDatePastOrToday]);

            // Department ID Validation
            RuleFor(x => x.Student.DepartmentId)
                .GreaterThan(0).WithMessage(_localizer[ResourceKeys.DepartmentIdGreaterThanZero])
                .MustAsync(async (departmentId, cancellation) =>
                    await _departmentService.DepartmentExists(departmentId))
                .WithMessage(_localizer[ResourceKeys.DepartmentNotFound]);

            // Student Uniqueness Validation
            RuleFor(x => x.Student)
                .MustAsync(async (student, cancellation) =>
                    await _studentService.IsStudentUnique(student.Email, student.Phone, student.NationalId))
                .WithMessage(_localizer[ResourceKeys.AlreadyExistsMessage]);

            // City Validation
            RuleFor(x => x.Student.City)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.CityRequired]);

            // Country Validation
            RuleFor(x => x.Student.Country)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.CountryRequired]);

            // National ID Validation
            RuleFor(x => x.Student.NationalId)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NationalIdRequired])
                .Matches(ValidationPatterns.NationalId).WithMessage(_localizer[ResourceKeys.NationalIdInvalidFormat]);

            // Postal Code Validation
            RuleFor(x => x.Student.PostalCode)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.PostalCodeRequired])
                .Matches(ValidationPatterns.PostalCode).WithMessage(_localizer[ResourceKeys.PostalCodeInvalidFormat]);

            // Emergency Contact Name Validation
            RuleFor(x => x.Student.EmergencyContactName)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmergencyContactNameRequired]);

            // Emergency Contact Phone Validation
            RuleFor(x => x.Student.EmergencyContactPhone)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmergencyContactPhoneRequired])
                .Matches(ValidationPatterns.PhoneNumber).WithMessage(_localizer[ResourceKeys.PhoneInvalidFormat]);

            // Emergency Contact Relation Validation
            RuleFor(x => x.Student.EmergencyContactRelation)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmergencyContactRelationRequired]);
        }
    }
}
