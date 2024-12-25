namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(Router.Authentication.Create)]
        public async Task<IActionResult> Create([FromBody] CreateDTO createDTO)
        {
            var response = await _mediator.Send(new CreateUserCommand(createDTO));

            return HandleResult(response);
        }
    }
}
