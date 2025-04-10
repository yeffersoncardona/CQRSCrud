using Microsoft.Data.SqlClient;

namespace CQRSCrud.Context
{
    public class ConexionDB
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;  
        public ConexionDB(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultConnection")!;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public bool GetMongoDB()
        {
            return _config.GetValue<bool>("MongoDB:Enabled");
        }
    }
}
