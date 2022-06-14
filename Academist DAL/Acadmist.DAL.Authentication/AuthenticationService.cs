using Acadmist.BAL.Component;
using Acadmist.BAL.Repository;
using Dotplus.Database.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.DAL.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        private readonly DotPlusData _db;
        public AuthenticationService(DotPlusData Database)
        {
            _db = Database;
        }

        public bool CheckUserWithType(string Usernamne, string UserType)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", Usernamne),
                    new SqlParameter("@Usertype", UserType)
                };
            var res = (int)_db.fn_ExecuteScalar("EC_SPCheckUsernameType", parameters);
            return res > 0;
        }

        public string ForgetPassword(string MobileNo)
        {
            throw new NotImplementedException();
        }

        public string LoginWithOTP(string Mobileno, string OTP)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MobileNo", Mobileno),
                    new SqlParameter("@OTP", OTP)
                };
            var res = (int)_db.fn_ExecuteScalar("EC_SPLoginWithOTP", parameters);
            if (res <= 0)
                throw new ArgumentException("Invalid OTP");

            return Mobileno;
        }

        public string LoginWithPassword(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public UserComponent LoginWithPassword(string Username, string UserType, string Password)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@Usertype", UserType),
                    new SqlParameter("@Password", Password)
                };
                var rdr = _db.fn_DataReader("EC_SPUserAuthecticatonBYUserType", parameters);
                if (rdr.Read())
                {
                    UserComponent userComponent = new UserComponent()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        UnivID = Convert.IsDBNull(rdr["UnivID"]) ? null : (int?)Convert.ToInt32(rdr["UnivID"]),
                        ClgID = Convert.ToInt32(rdr["ClgID"]),
                        Name = Convert.ToString(rdr["Name"]),
                        MobileNo = Convert.ToString(rdr["MobileNo"]),
                        EmailID = Convert.ToString(rdr["EmailID"]),
                        Username = Convert.ToString(rdr["Username"]),
                        Password = Convert.ToString(rdr["Password"]),
                        RoleID = Convert.IsDBNull(rdr["RoleID"]) ? null : (int?)Convert.ToInt32(rdr["RoleID"]) ,
                        sts = Convert.ToString(rdr["sts"]),
                        UserType = Convert.ToString(rdr["UserType"]),
                        ProfilePic = Convert.ToString(rdr["ProfilePic"]),
                    };
                    return userComponent;
                }
                else
                    return null;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public string OTPGenerate(string Mobileno)
        {
            try
            {
                Random _rdm = new Random();
                var OTP = _rdm.Next(1000, 9999);

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Mobileno", Mobileno),
                    new SqlParameter("@OTP", OTP)
                };
                var res = _db.fn_ExecuteNonQuery("EC_SPOTPGenerate", parameters);
                if (res <= 0)
                    throw new ArgumentException("invalid Mobile No");
                return OTP.ToString();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
