using MediatR;
using RedeTestCase.API.Application.Mediator.Base;

namespace RedeTestCase.API.Application.Features.Commands.Person
{
    public class DeletePersonRequest : IRequest<HandleResponse>
    {
        public int Id { get; set; }
    }
}
