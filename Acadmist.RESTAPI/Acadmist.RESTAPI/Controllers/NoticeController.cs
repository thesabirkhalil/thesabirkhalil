using Acadmist.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acadmist.RESTAPI.Controllers
{
    public class NoticeController : ApiController
    {
        private readonly INoticeBoard noticeBoard;
        private readonly ICollege college;

        public NoticeController(INoticeBoard noticeBoard, ICollege college)
        {
            this.noticeBoard = noticeBoard;
            this.college = college;
        }

        [HttpGet]
        public HttpResponseMessage GetActiveNotice(string URLCode)
        {
            var mycollege = college.GetCollege(URLCode);
            if (mycollege == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid College URL Code Suplied");
            }

            var result = noticeBoard.GetActiveNotice(mycollege.id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpGet]
        public HttpResponseMessage GetActiveNotice(string URLCode, string NoticeType)
        {
            var mycollege = college.GetCollege(URLCode);
            if (mycollege == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid College URL Code Suplied");
            }
            var result = noticeBoard.GetActiveNotice(mycollege.id, NoticeType);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
