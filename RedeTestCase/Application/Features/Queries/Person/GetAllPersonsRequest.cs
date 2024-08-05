using MediatR;
using RedeTestCase.API.Application.Mediator.Base;


namespace RedeTestCase.API.Application.Features.Queries.Person
{
    public class GetAllPersonsRequest : IRequest<HandleResponse>
    {
    }
}
