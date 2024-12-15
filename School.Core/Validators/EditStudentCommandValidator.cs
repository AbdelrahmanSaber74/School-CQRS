namespace School.Core.Features.Students.Commands.Validators
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentCommandValidator(IStudentService studentService)
        {
            _studentService = studentService;

            // Validate Name
            RuleFor(x => x.EditStudentDTO.Name)
                .NotEmpty().WithMessage(ValidationMessages.NameRequired)
                .MaximumLength(100).WithMessage(ValidationMessages.NameMaxLength);

            // Validate Phone
            RuleFor(x => x.EditStudentDTO.Phone)
                .NotEmpty().WithMessage(ValidationMessages.PhoneRequired)
                .Matches(ValidationPatterns.PhoneNumber).WithMessage(ValidationMessages.PhoneInvalidFormat);


            // Validate Email
            RuleFor(x => x.EditStudentDTO.Email)
                .NotEmpty().WithMessage(ValidationMessages.EmailRequired)
                .EmailAddress().WithMessage(ValidationMessages.EmailInvalidFormat);

            // Remove redundant checks
            RuleFor(x => x.EditStudentDTO)
                .MustAsync(async (student, cancellationToken) =>
                    !await _studentService.IsEmailExistExcludeSelf(student.Id, student.Email))
                .WithMessage(ValidationMessages.AlreadyExistsMessage);

            RuleFor(x => x.EditStudentDTO)
                .MustAsync(async (student, cancellationToken) =>
                    !await _studentService.IsPhoneExistExcludeSelf(student.Id, student.Phone))
                .WithMessage(ValidationMessages.AlreadyExistsMessage);
        }
    }
}
