using MediatR;
using RedeTestCase.API.Application.Mediator.Base;

namespace RedeTestCase.API.Application.Features.Queries.JobCategory
{
    public class GetAllJobsRequest : IRequest<HandleResponse>
    {
    }
}
