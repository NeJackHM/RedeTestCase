using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedeTestCase.API.Features.Commands;
using RedeTestCase.Domain.Features.Queries;

namespace RedeTestCase.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPersons")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPersonsRequest());

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
        }

        [HttpPost(Name = "RegisterPerson")]
        public async Task<IActionResult> Insert([FromBody] InsertPersonRequest insertPersonRequest)
        {
            var response = await _mediator.Send(insertPersonRequest);

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
        }
    }
}
