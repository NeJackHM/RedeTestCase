using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.API.Features.Commands.JobCategory
{
    public class InsertJobRequest : IRequest<HandleResponse>
    {
        public string Description { get; set; }
    }
}
