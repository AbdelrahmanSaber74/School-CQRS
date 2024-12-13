namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentCommandValidator()
        {
            RuleFor(x => x.Student.Name).NotEmpty().WithMessage(ValidationMessages.NameRequired)
                                         .MaximumLength(100).WithMessage(ValidationMessages.NameMaxLength);

            RuleFor(x => x.Student.Phone).NotEmpty().WithMessage(ValidationMessages.PhoneRequired)
                                          .Matches(ValidationPatterns.PhoneNumber).WithMessage(ValidationMessages.PhoneInvalidFormat);

            RuleFor(x => x.Student.Email).NotEmpty().WithMessage(ValidationMessages.EmailRequired)
                                          .EmailAddress().WithMessage(ValidationMessages.EmailInvalidFormat);

            RuleFor(x => x.Student.DateOfBirth).NotEmpty().WithMessage(ValidationMessages.DateOfBirthRequired)
                                                .Must(date => date < DateTime.Today).WithMessage(ValidationMessages.DateOfBirthPast);

            RuleFor(x => x.Student.EnrollmentDate).NotEmpty().WithMessage(ValidationMessages.EnrollmentDateRequired)
                                                  .Must(date => date <= DateTime.Today).WithMessage(ValidationMessages.EnrollmentDatePastOrToday);

            RuleFor(x => x.Student.DepartmentId).GreaterThan(0).WithMessage(ValidationMessages.DepartmentIdGreaterThanZero);
        }
    }
}
