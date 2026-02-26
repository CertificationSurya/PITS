using System.Data;
using Npgsql;

namespace Dashboard_MVC.Providers
{
    public static class ConnectionProvider {
        public static string _connectionString;

        public static void Initialize (IConfiguration config){
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public static IDbConnection GetConnection(){
            if (string.IsNullOrEmpty(_connectionString)){
                throw new InvalidOperationException(
                    "Database Provider isn't initialized. Call Initialize()"
                );
            }

            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}