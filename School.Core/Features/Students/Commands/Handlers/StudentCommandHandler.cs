namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IValidator<AddStudentCommand> _validator;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IValidator<AddStudentCommand> validator)
        {
            _studentService = studentService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {


            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest<string>(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var studentEntity = _mapper.Map<Student>(request.Student);

            var result = await _studentService.AddStudent(studentEntity);

            if (result == ResponseMessages.SuccessMessage)
            {
                return Success(result);

            }

            else if (result == ResponseMessages.AlreadyExistsMessage)
            {

                return UnprocessableEntity<string>(ResponseMessages.AlreadyExistsMessage);

            }


            else if (result == ResponseMessages.DepartmentNotFound)
            {

                return NotFound<string>(ResponseMessages.DepartmentNotFound);

            }

            return BadRequest<string>(result);

        }

    }
}
