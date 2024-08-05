using RedeTestCase.API.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;

namespace RedeTestCase.API.Features.Commands.Person
{
    public class UpdatePersonRequestHandler : AbstractRequestHandler<UpdatePersonRequest>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonRequestHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        internal override HandleResponse HandleIt(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newPerson = new Domain.Models.Person()
                {
                    Id = request.Id,
                    Name = request.Name,
                    BirthDate = request.BirthDate,
                    Country = request.Country,
                    Email = request.Email,
                    IsFreelance = request.IsFreelance,
                    Gender = request.Gender,
                    IsMarried = request.IsMarried,
                    JobCategoryId = request.JobCategoryId,
                    TelefoneNumber = request.TelefoneNumber
                };

                var isSuccess = _personRepository.Update(newPerson);
                if (isSuccess != 1)
                    return new HandleResponse { Error = "Problema para atualizar registro" };

                return new HandleResponse { Content = "Registro atualizado com sucesso", Error = string.Empty };
            }
            catch (Exception ex)
            {
                return new HandleResponse { Error = $"Problema para atualizar registro - Message :{ex.Message}" };
            }
        }
    }
}
