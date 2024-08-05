using Dapper;
using RedeTestCase.Domain.DataAccess.Repositories;
using RedeTestCase.Domain.Models;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace RedeTestCase.Infrastructure.DataAccess.Repositories
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly IDbConnection _connection;

        public JobCategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public int Delete(int id)
        {
            var sql = $@"UPDATE [dbo].[JobCategory]
                           SET [Active] = 0
                         WHERE Id = @Id;";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                Id = id
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public IEnumerable<JobCategory> GetAll()
        {
            var sql = $@"SELECT * FROM JobCategory;";
            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();
            var result = connection.Query<JobCategory>(sql);

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Insert(JobCategory entity)
        {
            var sql = $@"INSERT INTO [dbo].[JobCategory]
                       ([Description]
                       ,[Active]
                       ,[CreatedAt])
                 VALUES
                       (@Description
                       ,@Active
                       ,@CreatedAt);";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                Description = entity.Description,
                Active = entity.Active,
                CreatedAt = entity.CreatedAt,
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public int Update(JobCategory entity)
        {
            var sql = $@"UPDATE [dbo].[JobCategory]
                           SET [Description] = @Description
                         WHERE Id = @Id;";

            using var connection = new SqlConnection(_connection.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            var result = connection.Execute(sql, new
            {
                Id = entity.Id,
                Description = entity.Description
            });

            if (connection.State == ConnectionState.Open)
                connection.Close();

            return result;
        }

        public JobCategory GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
