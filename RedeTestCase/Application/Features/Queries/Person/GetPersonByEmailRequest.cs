using MediatR;
using RedeTestCase.API.Application.Mediator.Base;

namespace RedeTestCase.API.Application.Features.Queries.Person
{
    public class GetPersonByEmailRequest : IRequest<HandleResponse>
    {
        public string Email { get; set; }
    }
}
