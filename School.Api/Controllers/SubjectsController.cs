namespace School.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : BaseController
    {
        private readonly IMediator _mediator;



        public SubjectsController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            var result = await _mediator.Send(new GetAllSubjects());

            return Ok(result);

        }
    }
}
