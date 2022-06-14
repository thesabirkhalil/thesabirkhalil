using Acadmist.BAL.Repository;
using Acadmist.RESTAPI.OwinToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acadmist.RESTAPI.Controllers
{
    [Authorize]
    public class SMSOutboxController : ApiController
    {
        private readonly ISMSOutbox outbox;
        private readonly TokenAccess tokenAccess;

        public SMSOutboxController(ISMSOutbox outbox, TokenAccess tokenAccess)
        {
            this.outbox = outbox;
            this.tokenAccess = tokenAccess;
        }
        [HttpGet]
        public HttpResponseMessage GetNotification()
        {
            var result = outbox.GetSMSOutboxes(tokenAccess.UserID);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
