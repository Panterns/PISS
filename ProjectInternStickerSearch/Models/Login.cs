using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace ProjectInternStickerSearch.Models
{

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class Login
    {
        public int LogIn(string username, string password, bool rememberMe)
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
    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}