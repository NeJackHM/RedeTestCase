using Microsoft.Win32;
using RedeTestCase.API.Mediator.Base;
using RedeTestCase.Domain.DataAccess.Repositories;
using RedeTestCase.Domain.Models;

namespace RedeTestCase.API.Features.Commands
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
                var newPerson = new Person()
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
                    return new HandleResponse { Content = "Problema ao inserir registro", Error = string.Empty };

                return new HandleResponse { Error = "Registro inserido com sucesso" }; 
            }
            catch (Exception ex)
            {
                return new HandleResponse { Error = $"Problema ao inserir registro - Message :{ex.Message}" };
            }

        }
    }
}
