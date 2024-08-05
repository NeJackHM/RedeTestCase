using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.Domain.Features.Queries
{
    public class GetAllPersonsRequest : IRequest<HandleResponse>
    {
    }
}
