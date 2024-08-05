using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.API.Features.Queries.JobCategory
{
    public class GetAllJobsRequest : IRequest<HandleResponse>
    {
    }
}
