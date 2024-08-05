using RedeTestCase.API.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;
using RedeTestCase.Domain.Dtos;

namespace RedeTestCase.API.Features.Queries.Person
{
    public class GetAllPersonsRequestHandler : AbstractRequestHandler<GetAllPersonsRequest>
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;
        private readonly IPersonRepository _personRepository;
        //private readonly ILogger _logger;

        public GetAllPersonsRequestHandler(
            IJobCategoryRepository jobCategoryRepository,
            IPersonRepository personRepository
            //ILogger logger
            )
        {
            _jobCategoryRepository = jobCategoryRepository;
            _personRepository = personRepository;
            //_logger = logger;
        }

        internal override HandleResponse HandleIt(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new List<GetAllPersonsResponseDto>();
                var getAllPersons = _personRepository.GetAll();
                var getAllCategories = _jobCategoryRepository.GetAll();

                foreach (var person in getAllPersons)
                {
                    var jobDescription = getAllCategories.Where(x => x.Id == person.JobCategoryId).Select(x => x.Description).FirstOrDefault();
                    response.Add(new GetAllPersonsResponseDto()
                    {
                        PersonId = person.Id,
                        Active = person.Active,
                        BirthDate = person.BirthDate,
                        Country = person.Country,
                        Email = person.Email,
                        Gender = person.Gender,
                        IsFreelance = person.IsFreelance,
                        IsMarried = person.IsMarried,
                        JobCategoryDescription = jobDescription,
                        JobCategoryId = person.JobCategoryId,
                        Name = person.Name,
                        TelefoneNumber = person.TelefoneNumber
                    });
                }

                //_logger.LogInformation($"[{GetType().Name}] - Finish request");
                return new HandleResponse { Content = response, Error = string.Empty };
            }
            catch (Exception ex)
            {
                //_logger.LogError($"[{GetType().Name}] - Error Request - Message {ex.Message}");
                return new HandleResponse { Error = "Error during request." };
            }
        }
    }
}
