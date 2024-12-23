namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        public DepartmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route(Router.Departments.GetAll)]
        public async Task<IActionResult> GetDepartmentsAsync()
        {
            // Send the query to the mediator to get the department list
            var result = await _mediator.Send(new GetDepartmentsListAsyncQuery());

            // Handle and return the result
            return HandleResult(result);
        }


        [HttpGet]
        [Route(Router.Departments.GetById)]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            // Send the query to the mediator to get the department list
            var result = await _mediator.Send(new GetDepartmentByIdAsyncQuery(id));

            // Handle and return the result
            return HandleResult(result);
        }
    }
}
