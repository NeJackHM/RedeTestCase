using RedeTestCase.API.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;

namespace RedeTestCase.API.Features.Queries.JobCategory
{
    public class GetAllJobsRequestHandler : AbstractRequestHandler<GetAllJobsRequest>
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public GetAllJobsRequestHandler(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        internal override HandleResponse HandleIt(GetAllJobsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _jobCategoryRepository.GetAll();
                return new HandleResponse { Content = response, Error = string.Empty };
            }
            catch (Exception ex)
            {
                return new HandleResponse
                {
                    Error = $"Error during request - Message {ex.Message}"
                };
            }
        }
    }
}
