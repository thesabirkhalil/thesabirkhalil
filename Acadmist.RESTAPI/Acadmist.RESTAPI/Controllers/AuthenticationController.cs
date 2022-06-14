using Acadmist.BAL.Repository;
using Acadmist.RESTAPI.Models;
using Acadmist.RESTAPI.OwinToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acadmist.RESTAPI.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthentication authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        [HttpPost]
        public HttpResponseMessage CheckUser(UserLogin userLogin)
        {
            try
            {
                var res = authentication.CheckUserWithType(userLogin.Username, userLogin.UserTYpe);
                if (!res)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Username Suplied");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Valid User");
                }
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }

        [HttpGet]
        [Authorize]
        public HttpResponseMessage CheckToken()
        {
            try
            {
                TokenAccess _tokenAccess = new TokenAccess();
                return Request.CreateResponse(HttpStatusCode.OK, _tokenAccess);

            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exp);
            }
        }


    }
}
