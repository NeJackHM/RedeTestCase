using Dapper;
using RedeTestCase.Domain.DataAccess.Repositories;
using RedeTestCase.Domain.Models;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace RedeTestCase.Infrastructure.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _connection;

        public PersonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Person GetByEmail(string email)
        {
            var sql = $@"SELECT * FROM Person WHERE Email = '{email}';";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.QueryFirst<Person>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Delete(int id)
        {
            var sql = $@"UPDATE[dbo].[Person]
                               SET[Status] = 0
                             WHERE Id = @Id;";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new { Id = id });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public IEnumerable<Person> GetAll()
        {
            var sql = $@"SELECT * FROM Person;";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.Query<Person>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public Person GetById(int id)
        {
            var sql = $@"SELECT * FROM Person WHERE ID = {id};";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.QueryFirst<Person>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Insert(Person entity)
        {
            var sql = $@"INSERT INTO [dbo].[Person]
                       ([JobCategoryId]
                       ,[Name]
                       ,[Email]
                       ,[Gender]
                       ,[BirthDate]
                       ,[CreatedAt]
                       ,[TelefoneNumber]
                       ,[Country]
                       ,[IsFreelance]
                       ,[IsMarried]
                       ,[Active])
                 VALUES
                       (@JobCategoryId
                       ,@Name
                       ,@Email
                       ,@Gender
                       ,@BirthDate
                       ,@CreatedAt
                       ,@TelefoneNumber
                       ,@Country
                       ,@IsFreelance
                       ,@IsMarried
                       ,@Active);";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                JobCategoryId = entity.JobCategoryId,
                Name = entity.Name,
                Email = entity.Email,
                Gender = entity.Gender,
                BirthDate = entity.BirthDate,
                CreatedAt = entity.CreatedAt,
                TelefoneNumber = entity.TelefoneNumber,
                Country = entity.Country,
                IsFreelance = entity.IsFreelance,
                IsMarried = entity.IsMarried,
                Active = entity.Active
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Update(Person entity)
        {
            var sql = $@"UPDATE[dbo].[Person]
                               SET[JobCategoryId] = @JobCategoryId
                                  ,[Name] = @Name
                                  ,[Email] = @Email
                                  ,[Gender] = @Gender
                                  ,[BirthDate] = @BirthDate
                                  ,[TelefoneNumber] = @TelefoneNumber
                                  ,[Country] = @Country
                                  ,[IsFreelance] = @IsFreelance
                                  ,[IsMarried] = @IsMarried
                             WHERE Id = @Id;";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                Id = entity.Id,
                JobCategoryId = entity.JobCategoryId,
                Name = entity.Name,
                Email = entity.Email,
                Gender = entity.Gender,
                BirthDate = entity.BirthDate,
                TelefoneNumber = entity.TelefoneNumber,
                Country = entity.Country,
                IsFreelance = entity.IsFreelance,
                IsMarried = entity.IsMarried
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }
    }
}
