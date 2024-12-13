namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(
            IStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {

            // Map the command to the student entity
            var studentEntity = _mapper.Map<Student>(request.Student);

            // Add the student using the service
            var result = await _studentService.AddStudent(studentEntity);

            return result switch
            {
                ResponseMessages.SuccessMessage => Success(result),
                ResponseMessages.AlreadyExistsMessage => UnprocessableEntity<string>(ResponseMessages.AlreadyExistsMessage),
                ResponseMessages.DepartmentNotFound => NotFound<string>(ResponseMessages.DepartmentNotFound),
                _ => BadRequest<string>(result),
            };
        }
    }
}
