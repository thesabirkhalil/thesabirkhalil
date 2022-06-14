using Acadmist.BAL.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface IAuthentication
    {
        string LoginWithPassword(string Username, string Password);
        UserComponent LoginWithPassword(string Username, string UserType, string Password);
        string OTPGenerate(string Mobileno);
        string LoginWithOTP(string Mobileno, string OTP);
        string ForgetPassword(string MobileNo);
        bool CheckUserWithType(string Usernamne, string UserType);
    }
}
