using School.Core.Dto.Student;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : BaseController
    {
        public StudentsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route(Router.Students.GetAll)]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _mediator.Send(new GetStudentsListQuery());
            return HandleResult(result);
        }

        [HttpPost]
        [Route(Router.Students.Add)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDTO studentDTO)
        {
            var result = await _mediator.Send(new AddStudentCommand(studentDTO));
            return HandleResult(result);
        }

        [HttpGet]
        [Route(Router.Students.GetById)]
        public async Task<IActionResult> GetStudentById(string studentId)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(studentId));
            return HandleResult(result);
        }

        [HttpPost]
        [Route(Router.Students.Edit)]
        public async Task<IActionResult> EditStudent(EditStudentDTO editStudentDTO)
        {
            var result = await _mediator.Send(new EditStudentCommand(editStudentDTO));
            return HandleResult(result);
        }

        [HttpPost]
        [Route(Router.Students.Delete)]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(studentId));
            return HandleResult(result);
        }

        [HttpGet]
        [Route(Router.Students.GetPaginated)]
        public async Task<IActionResult> GetPaginatedStudents(int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetPaginatedStudentsListQuery(pageNumber, pageSize));
            return HandleResult(result);
        }
    }
}
