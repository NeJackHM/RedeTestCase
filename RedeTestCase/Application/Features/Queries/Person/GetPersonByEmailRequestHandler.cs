using RedeTestCase.API.Application.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;

namespace RedeTestCase.API.Application.Features.Queries.Person
{
    public class GetPersonByEmailRequestHandler : AbstractRequestHandler<GetPersonByEmailRequest>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByEmailRequestHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        internal override HandleResponse HandleIt(GetPersonByEmailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _personRepository.GetByEmail(request.Email);

                if (response != null)
                    return new HandleResponse { Content = response, Error = string.Empty };

                return new HandleResponse { Error = "Person not found" };
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
