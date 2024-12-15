using Microsoft.AspNetCore.Http.HttpResults;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
                                                          IRequestHandler<EditStudentCommand, Response<string>>
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

            if (result == ResponseMessages.SuccessMessage)
            {
                return Created(string.Empty, result);
            }

            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {

            var studentEntity = _mapper.Map<Student>(request.EditStudentDTO);

            var result =  await _studentService.EditStudent(studentEntity);

            if (result == ResponseMessages.StudentUpdatedSuccessfully)
            {

                return Success(string.Empty, result);   
            }

            return NotFound<string>(result);

        }
    }
}
