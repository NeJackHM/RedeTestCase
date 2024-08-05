using RedeTestCase.API.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;
using RedeTestCase.Domain.Features.Queries;
using Serilog;

namespace RedeTestCase.API.Features.Queries
{
    public class GetAllPersonsRequestHandler : AbstractRequestHandler<GetAllPersonsRequest>
    {
        private readonly IPersonRepository _personRepository;
        //private readonly Serilog.ILogger _logger;

        public GetAllPersonsRequestHandler(
            IPersonRepository personRepository
            //Serilog.ILogger logger
            )
        {
            _personRepository = personRepository;
            //_logger = logger;
        }

        internal override HandleResponse HandleIt(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _personRepository.GetAll();
                //_logger.Information($"[{GetType().Name}] - Finish request");
                return new HandleResponse { Content = response, Error = string.Empty };
            }
            catch (Exception ex)
            {
                //_logger.Error($"[{GetType().Name}] - Error Request - Message {ex.Message}");
                return new HandleResponse { Error = "Error during request." };
            }

        }
    }
}
