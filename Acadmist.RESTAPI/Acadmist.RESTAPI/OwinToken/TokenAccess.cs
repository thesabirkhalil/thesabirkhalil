using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Acadmist.RESTAPI.OwinToken
{
    public class TokenAccess
    {
        private readonly ClaimsIdentity cidentity;

        public TokenAccess()
        {
            cidentity = ClaimsPrincipal.Current.Identities.First();
        }
        public int UserID
        {
            get
            {
                return Convert.ToInt32(cidentity.Name);
            }
        }
        public string Role
        {
            get
            {
                return cidentity.Claims.Where(w => w.Type == ClaimTypes.Role).Select(w => w.Value).FirstOrDefault();
            }
        }
        public string username
        {
            get
            {
                return cidentity.Claims.Where(w => w.Type == "username").Select(w => w.Value).FirstOrDefault();
            }
        }
        public string Name
        {
            get
            {
                return cidentity.Claims.Where(w => w.Type == "Name").Select(w => w.Value).FirstOrDefault();
            }
        }
        public string MobileNo
        {
            get
            {
                return cidentity.Claims.Where(w => w.Type == "MobileNo").Select(w => w.Value).FirstOrDefault();
            }
        }

        public int  CollegeID
        {
            get
            {
                return cidentity.Claims.Where(w => w.Type == "collegeID").Select(w => Convert.ToInt32(w.Value)).FirstOrDefault();
            }
        }


    }
}