using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.API.Features.Queries.Person
{
    public class GetPersonByEmailRequest : IRequest<HandleResponse>
    {
        public string Email { get; set; }
    }
}
