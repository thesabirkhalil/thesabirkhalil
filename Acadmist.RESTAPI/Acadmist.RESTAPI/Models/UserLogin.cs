using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acadmist.RESTAPI.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserTYpe { get; set; }

    }
}