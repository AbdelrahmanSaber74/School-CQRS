using MediatR;
using School.Core.Features.Students.Queries.Models;

namespace School.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudentsList()
        {
            var result = await _mediator.Send(new GetStudentsListQuery() );

            return Ok(result);

        }
    }
}
