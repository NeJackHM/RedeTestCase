using MediatR;
using RedeTestCase.API.Application.Mediator.Base;

namespace RedeTestCase.API.Application.Features.Commands.JobCategory
{
    public class InsertJobRequest : IRequest<HandleResponse>
    {
        public string Description { get; set; }
    }
}
