namespace School.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : BaseController
    {
        public StudentsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route(Router.Students.GetAll)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetStudentsListQuery());

            return HandleResult(result);

        }

        [HttpPost]
        [Route(Router.Students.AddStudent)]
        public async Task<IActionResult> Post([FromBody] AddStudentDTO studentDTO)
        {
            var result = await _mediator.Send(new AddStudentCommand(studentDTO));

            return HandleResult(result);


        }

        [HttpGet]
        [Route(Router.Students.GetById)]

        public async Task<IActionResult> Get(string studentId)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(studentId));
            return HandleResult(result);
        }

        [HttpPost]
        [Route(Router.Students.EditStudent)]

        public async Task<IActionResult> Get(EditStudentDTO editStudentDTO)
        {
            var result = await _mediator.Send(new EditStudentCommand(editStudentDTO));
            return HandleResult(result);
        }


        [HttpPost]
        [Route(Router.Students.DeleteStudent)]

        public async Task<IActionResult> Delete(string studentId)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(studentId));
            return HandleResult(result);
        }


        [HttpGet]
        [Route(Router.Students.GetPaginatedStudents)]
        public async Task<IActionResult> Get(int pageNumber , int pageSize)
        {
            var result = await _mediator.Send(new GetPaginatedStudentsListQuery(pageNumber , pageSize));
            return HandleResult(result);
        }
    }
}
