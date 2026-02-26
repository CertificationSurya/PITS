using System.Data;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Dashboard_MVC.Providers;
using Npgsql;
// using Microsoft.EntityFrameworkCore; // for <ApplicationDbContext> in ef. dapper send IDbConnection

namespace Dashboard_MVC.Extensions
{
    public static class DbServiceCollectionExtensions
    {
        // DiConfig will provide us service and configuration (from appsetting)
        public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            // Initialize static connection provider
            ConnectionProvider.Initialize(configuration);

            // Register IDbConnection factory for Dapper
            services.AddScoped<IDbConnection>(sp =>
            {
                var conn = ConnectionProvider.GetConnection();
                return conn;
            });

            return services;
        }
        
    }
}