using EventFinal.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace EventFinal.Repositories
{
    public class LoginRepository: BaseRepository,ILoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        { }
        public Registration Login(string Username, string Password)
        {
            // var query = @"EXEC" + "LoginUser" + "@Username,@Password";
            var query = "select * From Registration where Username= @Username and Password=@Password";
            using (var connection = Connect())
            {
                Registration registration = connection.QuerySingle<Registration>(query, new { Username, Password });
                return registration;
            }
        }
    }
}
