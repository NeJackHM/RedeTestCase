using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedeTestCase.API.Features.Commands.JobCategory;
using RedeTestCase.API.Features.Commands.Person;
using RedeTestCase.API.Features.Queries.JobCategory;
using RedeTestCase.API.Features.Queries.Person;

namespace RedeTestCase.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobCategoryController : Controller
    {
        private readonly IMediator _mediator;

        public JobCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllJobs")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllJobsRequest());

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
        }

        [HttpPost(Name = "RegisterJob")]
        public async Task<IActionResult> Insert([FromBody] InsertJobRequest insertPersonRequest)
        {
            var response = await _mediator.Send(insertPersonRequest);

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
        }
    }
}
