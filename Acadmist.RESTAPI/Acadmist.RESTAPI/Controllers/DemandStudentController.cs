using Acadmist.BAL.Repository;
using Acadmist.RESTAPI.Models;
using Acadmist.RESTAPI.OwinToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Acadmist.RESTAPI.Controllers
{
    [Authorize(Roles = "Student")]
    public class DemandStudentController : ApiController
    {
        private readonly IDemandStudent _demandStudent;
        private readonly TokenAccess _tokenAccess;
        private readonly ISetting _setting;
        private readonly ICompany _company;
        private readonly IDemandDetail _demandDetail;
        private readonly vm_Response _Response;

        public DemandStudentController(IDemandStudent demandStudent, TokenAccess tokenAccess, ISetting setting, ICompany company,
            IDemandDetail demandDetail, vm_Response Response)
        {
            this._demandStudent = demandStudent;
            this._tokenAccess = tokenAccess;
            this._setting = setting;
            this._company = company;
            this._demandDetail = demandDetail;
            _Response = Response;
        }
        [HttpGet]
        public HttpResponseMessage GetFeeDue()
        {
            DemandList_StudentView StudentdemandList = new DemandList_StudentView();
            var DemandList = _demandStudent.GetFeeDue(_tokenAccess.UserID);
            if (_setting.GetSetting(_tokenAccess.CollegeID).isCompanyFeeFilter)
            {
                HashSet<int> CompID = new HashSet<int>(DemandList.Select(w => Convert.ToInt32(w.CompanyID)).ToList());
                StudentdemandList.Companies = _company.GetCompanies(_tokenAccess.CollegeID).Where(w => CompID.Contains(w.id)).ToList();
            }

            StudentdemandList.demandLists = DemandList;
            return Request.CreateResponse(HttpStatusCode.OK, StudentdemandList);
        }
        [HttpGet]
        public HttpResponseMessage GetPaymentReceipt()
        {
            var claimf = (ClaimsIdentity)User.Identity;
            int StudenID = Convert.ToInt32(claimf.Name);
            var result = _demandStudent.GetPaymentReceipt(StudenID);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetDemandDetail(int DemandID)
        {
                // int i = 100;
            var result = _demandDetail.GetDemandDetails_Student(DemandID, _tokenAccess.UserID);
            if (result.Count() <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, _Response.Failed("Invalid Demand Suplied"));
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


    }
}
