using Acadmist.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acadmist.RESTAPI.Controllers
{
    public class CollegeController : ApiController
    {
        private readonly ICollege college;

        public CollegeController(ICollege college)
        {
            this.college = college;
        }

        [HttpGet]
        public HttpResponseMessage GetCollegeByURL(string URLCode)
        {
            try
            {
                var result = college.GetCollege(URLCode);
                if (result == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid College URL Code Suplied");
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, exp);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCollegeByID(int ID)
        {
            try
            {
                var result = college.GetCollege(ID);
                if (result == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid College ID Suplied");
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, exp);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCollegeByUniversity(int ID)
        {
            try
            {
                var result = college.GetColleges(ID);
                if (result.Count ==0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid University ID Suplied");
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception exp)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, exp);
            }
        }

    }
}
