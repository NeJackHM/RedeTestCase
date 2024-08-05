using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.API.Features.Queries.Person
{
    public class GetAllPersonsRequest : IRequest<HandleResponse>
    {
    }
}
