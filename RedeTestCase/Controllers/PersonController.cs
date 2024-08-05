using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedeTestCase.API.Features.Commands.Person;
using RedeTestCase.API.Features.Queries.Person;

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

        [HttpGet("{email}", Name = "GetCustomer")]
        public async Task<IActionResult> GetById(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var response = await _mediator.Send(new GetPersonByEmailRequest { Email = email });

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
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

        [HttpPut(Name = "UpdatePerson")]
        public async Task<IActionResult> Update([FromBody] UpdatePersonRequest updatePersonRequest)
        {
            var response = await _mediator.Send(updatePersonRequest);

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
        }

        [HttpDelete(Name = "DeletePerson")]
        public async Task<IActionResult> Delete([FromBody] DeletePersonRequest deletePersonRequest)
        {
            var response = await _mediator.Send(deletePersonRequest);

            if (response.Error != string.Empty)
                return BadRequest($"{response.Error}");

            return Ok(response);
        }
    }
}
