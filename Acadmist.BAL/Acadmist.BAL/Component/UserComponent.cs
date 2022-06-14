using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Component
{
    public class UserComponent
    {
        public int id { get; set; }
        public int? UnivID { get; set; }
        public int ClgID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleID { get; set; }
        public int isOTPSend { get; set; }
        public string sts { get; set; }
        public string UserType { get; set; }
        public string MenuLink { get; set; }
        public string ProfilePic { get; set; }
        public string EmpCode { get; set; }
    }
}
