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
            var result = await _mediator.Send(new GetDepartmentsListAsyncQuery());

            return HandleResult(result);
        }


        [HttpGet]
        [Route(Router.Departments.GetById)]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdAsyncQuery(id));

            return HandleResult(result);
        }
    }
}
