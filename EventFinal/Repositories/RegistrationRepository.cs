using Dapper;
using EventFinal.Models;
using Microsoft.Data.SqlClient;
namespace EventFinal.Repositories
{
    public class RegistrationRepository : BaseRepository, IRegistrationRepository
    {
        public RegistrationRepository(IConfiguration configuration) : base(configuration) { }
        public int CreateUser(Registration register)
        {
            int rowAffected = 0;
            using (var connection = Connect())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", register.Name);
                parameters.Add("@Address", register.Address);
                parameters.Add("@City", register.City);
                parameters.Add("@State", register.State);
                parameters.Add("@Country", register.Country);
                parameters.Add("@Mobileno", register.Mobileno);
                parameters.Add("@EmailID", register.EmailID);
                parameters.Add("@Username", register.Username);
                parameters.Add("@Password", register.Password);
                parameters.Add("@ConfirmPassword", register.ConfirmPassword);
                parameters.Add("@Gender", register.Gender);
                parameters.Add("@Birthdate", register.Birthdate);
                parameters.Add("@RoleID", register.RoleID);


                parameters.Add("@Code", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                parameters.Add("@Message", register.Message, direction: System.Data.ParameterDirection.Output);

                rowAffected = connection.Execute("AddRegistration", parameters, commandType: System.Data.CommandType.StoredProcedure);

                int Code = parameters.Get<int>("@Code");
                string Message = parameters.Get<string>("Message");
            }
            return rowAffected;
        }
    }
}

        //public class RegistrationRepository: BaseRepository, IRegistrationRepository
        //{
        //    public RegistrationRepository(IConfiguration configuration) : base(configuration) { }
        //    public bool AddRegistration(Registration register)
        //    {
        //        int rowAffected = 0;
        //        using (var connection = Connect())
        //        {
        //            DynamicParameters parameters = new DynamicParameters();
        //            parameters.Add("@Name", register.Name);
        //            parameters.Add("@Address", register.Address);
        //            parameters.Add("@City", register.City);
        //            parameters.Add("@State", register.State);
        //            parameters.Add("@Country", register.Country);
        //            parameters.Add("@Mobileno", register.Mobileno);
        //            parameters.Add("@EmailID", register.EmailID);
        //            parameters.Add("@Username", register.Username);
        //            parameters.Add("@Password", register.Password);
        //            parameters.Add("@ConfirmPassword", register.ConfirmPassword);
        //            parameters.Add("@Gender", register.Gender);
        //            parameters.Add("@Birthdate", register.Birthdate);
        //            parameters.Add("@RoleID", register.RoleID);


        //            parameters.Add("@Code", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
        //            parameters.Add("@Message", register.Message, direction: System.Data.ParameterDirection.Output);

        //            rowAffected = connection.Execute("AddRegistration", parameters, commandType: System.Data.CommandType.StoredProcedure);

        //            int Code = parameters.Get<int>("@Code");
        //            string Message = parameters.Get<string>("Message");
        //        }
        //        return rowAffected > 0 ? true : false;
        //    }
        //}
    
