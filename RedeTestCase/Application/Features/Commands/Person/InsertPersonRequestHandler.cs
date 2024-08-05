using RedeTestCase.API.Application.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;

namespace RedeTestCase.API.Application.Features.Commands.Person
{
    public class InsertPersonRequestHandler : AbstractRequestHandler<InsertPersonRequest>
    {
        private readonly IPersonRepository _personRepository;

        public InsertPersonRequestHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        internal override HandleResponse HandleIt(InsertPersonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newPerson = new Domain.Models.Person()
                {
                    Name = request.Name,
                    BirthDate = request.BirthDate,
                    Country = request.Country,
                    Email = request.Email,
                    IsFreelance = request.IsFreelance,
                    Active = true,
                    Gender = request.Gender,
                    IsMarried = request.IsMarried,
                    JobCategoryId = request.JobCategoryId,
                    CreatedAt = DateTime.Now,
                    TelefoneNumber = request.TelefoneNumber
                };

                var isSuccess = _personRepository.Insert(newPerson);
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
