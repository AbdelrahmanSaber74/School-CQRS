namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AddStudentCommandValidator(IStudentService studentService, IStringLocalizer<SharedResource> localizer)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));

            RuleFor(x => x.Student.Name)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.NameRequired])
                .MaximumLength(100).WithMessage(_localizer[ResourceKeys.NameMaxLength]);

            RuleFor(x => x.Student.Phone)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.PhoneRequired])
                .Matches(ValidationPatterns.PhoneNumber).WithMessage(_localizer[ResourceKeys.PhoneInvalidFormat]);

            RuleFor(x => x.Student.Email)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EmailRequired])
                .EmailAddress().WithMessage(_localizer[ResourceKeys.EmailInvalidFormat]);

            RuleFor(x => x.Student.DateOfBirth)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.DateOfBirthRequired])
                .Must(date => date < DateTime.Today).WithMessage(_localizer[ResourceKeys.DateOfBirthPast]);

            RuleFor(x => x.Student.EnrollmentDate)
                .NotEmpty().WithMessage(_localizer[ResourceKeys.EnrollmentDateRequired])
                .Must(date => date <= DateTime.Today).WithMessage(_localizer[ResourceKeys.EnrollmentDatePastOrToday]);

            RuleFor(x => x.Student.DepartmentId)
                .GreaterThan(0).WithMessage(_localizer[ResourceKeys.DepartmentIdGreaterThanZero])
                .MustAsync(async (departmentId, cancellation) =>
                    await _studentService.DepartmentExists(departmentId))
                .WithMessage(_localizer[ResourceKeys.DepartmentNotFound]);

            RuleFor(x => x.Student)
                .MustAsync(async (student, cancellation) =>
                    await _studentService.IsStudentUnique(student.Email, student.Phone))
                .WithMessage(_localizer[ResourceKeys.AlreadyExistsMessage]);
        }
    }
}