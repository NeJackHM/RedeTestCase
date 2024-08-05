using RedeTestCase.Domain.DataAccess.Repositories.Base;
using RedeTestCase.Domain.Dtos;
using RedeTestCase.Domain.Models;

namespace RedeTestCase.Domain.DataAccess.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        GetPersonByEmailResponseDto GetByEmail(string email);
    }
}
