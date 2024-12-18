namespace School.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public SubjectsController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        // Example GET endpoint
        [HttpGet]
        public IActionResult Get()
        {


            var meesage = _localizer[ResourceKeys.WelcomeMessage];

            return Ok(meesage);

        }
    }
}
