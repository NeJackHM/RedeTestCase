using RedeTestCase.Domain.DataAccess.Repositories.Base;
using RedeTestCase.Domain.Models;

namespace RedeTestCase.Domain.DataAccess.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByEmail(string email);
    }
}
