using Acadmist.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acadmist.RESTAPI.Controllers
{
    public class BannerController : ApiController
    {
        private readonly IBanner banner;
        private readonly ICollege college;

        public BannerController(IBanner banner, ICollege college)
        {
            this.banner = banner;
            this.college = college;
        }

        [HttpGet]
        public HttpResponseMessage GetBannerByCollege(string URLCode)
        {
            var mycollege = college.GetCollege(URLCode);
            if (mycollege == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid College URL Code Suplied");
            }

            var result = banner.GetBanners(mycollege.id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
