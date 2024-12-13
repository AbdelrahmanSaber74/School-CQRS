using School.Core.Dto;
using School.Core.Features.Students.Commands.Models;

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

        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return HandleResult(result);
        }

    }
}
