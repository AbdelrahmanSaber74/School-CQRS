namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route(Router.Users.GetByEmail)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _mediator.Send(new GetUserByEmailQuery(email));
            return HandleResult(result);
        }
    }
}
