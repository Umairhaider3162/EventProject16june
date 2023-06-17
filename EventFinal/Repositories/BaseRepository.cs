using Microsoft.Data.SqlClient;
using System.Data;

namespace EventFinal.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected IDbConnection Connect()
        {
            return new SqlConnection(_configuration.GetConnectionString("string"));
           // return new SqlConnection(_configuration.GetConnectionString("string"))
        }

    }
}
