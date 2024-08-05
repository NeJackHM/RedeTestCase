using MediatR;
using RedeTestCase.Domain.DataAccess.Repositories;
using RedeTestCase.Infrastructure.DataAccess.Repositories;
using System.Data.SqlClient;
using System.Data;
using Serilog;

namespace RedeTestCase.API.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        private static IConfigurationRoot _configuration;

        public static WebApplicationBuilder AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddTransient<IJobCategoryRepository, JobCategoryRepository>();

            builder.Services.AddTransient<IDbConnection>((sp) =>
            {
                var configuration = builder.Configuration;
                var connectionString = configuration.GetConnectionString("ConnectionString");
                return new SqlConnection(connectionString);
            });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            return builder;
        }
    }
}
