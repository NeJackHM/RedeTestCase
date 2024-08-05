using RedeTestCase.API.Application.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;

namespace RedeTestCase.API.Application.Features.Commands.Person
{
    public class DeletePersonRequestHandler : AbstractRequestHandler<DeletePersonRequest>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonRequestHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        internal override HandleResponse HandleIt(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var isSuccess = _personRepository.Delete(request.Id);
                if (isSuccess != 1)
                    return new HandleResponse { Error = "Problema ao deletar registro" };

                return new HandleResponse { Content = "Registro deletado com sucesso", Error = string.Empty };
            }
            catch (Exception ex)
            {
                return new HandleResponse { Error = $"Problema ao deletar registro - Message :{ex.Message}" };
            }
        }
    }
}
