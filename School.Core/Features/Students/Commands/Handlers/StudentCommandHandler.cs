using School.Data.Consts;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request.Student);

            var result = await _studentService.AddStudent(studentEntity);

            if (result == Messages.SuccessMessage)
            {
                return Success(result);

            }

            else if (result == Messages.AlreadyExistsMessage)
            {

                return UnprocessableEntity<string>(Messages.AlreadyExistsMessage);

            }


            else if (result == Messages.DepartmentNotFound)
            {

                return NotFound<string>(Messages.DepartmentNotFound);

            }

            return BadRequest<string>(result);

        }

    }
}
