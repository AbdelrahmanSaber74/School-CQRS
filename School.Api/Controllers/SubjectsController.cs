using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Subjects.Queries.Models;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            var result = await _mediator.Send(new GetAllSubjects());

            return Ok(result);

        }
    }
}
