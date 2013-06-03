using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ProjectInternStickerSearch.Models
{
    public class Login
    {
        public int LogIn(string username, string password)
        {
            using (var connection = new SqlConnection("Server=qadev0db-dev\\dev,50400;Database=QA;User Id=uPSavkovich;Password=uPS11137350!;"))
            {
                connection.Open();
                var parms = new DynamicParameters();
                parms.Add("@Username", username);
                parms.Add("@Password", password);
                parms.Add("@Result", 0, DbType.Int32, ParameterDirection.Output);

                var login = SqlMapper.Query<int>(connection, "Intern.ConfirmLogIn",
                                                          commandType: CommandType.StoredProcedure,
                                                          param: parms);
                System.Console.WriteLine("hello");
                System.Console.WriteLine(login);
                return parms.Get<int>("@Result");
            }
        }
    }
}