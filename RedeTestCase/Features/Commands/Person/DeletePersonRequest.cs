using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.API.Features.Commands.Person
{
    public class DeletePersonRequest : IRequest<HandleResponse>
    {
        public int Id { get; set; }
    }
}
