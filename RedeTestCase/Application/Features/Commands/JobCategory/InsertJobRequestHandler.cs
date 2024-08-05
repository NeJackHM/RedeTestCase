using RedeTestCase.API.Application.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;

namespace RedeTestCase.API.Application.Features.Commands.JobCategory
{
    public class InsertJobRequestHandler : AbstractRequestHandler<InsertJobRequest>
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public InsertJobRequestHandler(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        internal override HandleResponse HandleIt(InsertJobRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newJobCategory = new Domain.Models.JobCategory()
                {
                    Active = true,
                    CreatedAt = DateTime.UtcNow,
                    Description = request.Description
                };

                var isSuccess = _jobCategoryRepository.Insert(newJobCategory);
                if (isSuccess != 1)
                    return new HandleResponse { Error = "Problema ao inserir registro" };

                return new HandleResponse { Content = "Registro inserido com sucesso", Error = string.Empty };
            }
            catch (Exception ex)
            {
                return new HandleResponse { Error = $"Problema ao inserir registro - Message :{ex.Message}" };
            }
        }
    }
}
