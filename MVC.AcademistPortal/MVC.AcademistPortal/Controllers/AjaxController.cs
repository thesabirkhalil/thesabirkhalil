using Dotplus.Database.StoreProcedure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.AcademistPortal.Models;

namespace MVC.AcademistPortal.Controllers
{
    public class AjaxController : Controller
    {
        private Database db;
        public AjaxController()
        {
            db = Database.GetInstance("DBCS");
        }
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetProgram(string URLCode)
        {
            Database db = Database.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
               {
               
                new SqlParameter("@CLGCode", URLCode)
               };
            var Result = db.fn_DataTable("AD_SPGetProgram", parameters);
            return Json(JsonConvert.SerializeObject(Result), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSemester(int Progid, string URLCode)
        {
            Database db = Database.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("@CLGCode", URLCode),
                new SqlParameter("@Progid", Progid)
               };
            var Result = db.fn_DataTable("AD_SPGetSemester", parameters);
            return Json(JsonConvert.SerializeObject(Result), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetStudentBasedSession(int program, string URLCode)
        {
            Database db = Database.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("@CLGCode", URLCode),
                new SqlParameter("@Progid", program)
               };
            var Result = db.fn_DataTable("AD_SPGetStudentBasedSession", parameters);
            return Json(JsonConvert.SerializeObject(Result), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCollge()
        {
            Database db = Database.GetInstance();
           
            var Result = db.fn_DataTable("AD_SPGetCollege");
            return Json(JsonConvert.SerializeObject(Result), JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult StudentListForERPFee(int? program, int? sem, int? intake, string URLCode, string sts, string Collegeno)
        {
            Database db = Database.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
               {
               
                new SqlParameter("@Sem", sem),
                new SqlParameter("@Intake", intake),
                new SqlParameter("@Progid", program),
                new SqlParameter("@URLCode", URLCode),
                new SqlParameter("@Collegeno", Collegeno),
                 new SqlParameter("@sts", sts)
               };
            var Result = db.fn_DataTable("AD_SPGetStudentListCurrentProfile", parameters);
            return Json(JsonConvert.SerializeObject(Result), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult PostErpFee(int? program, int? sem, int? ERPSem, int? intake, string URLCode, string sts, string Collegeno)
        {
            
            Success success = new Success();

            if (sts == "")
            {
                sts = null;
            }
            if (Collegeno == "")
            {
                Collegeno = null;
            }

            SqlParameter[] parameters = new SqlParameter[]
               {
                new SqlParameter("@ERPSem", ERPSem),
                new SqlParameter("@Sem", sem),
                new SqlParameter("@Intake", intake),
                new SqlParameter("@Progid", program),
                new SqlParameter("@URLCode", URLCode),
                new SqlParameter("@Collegeno", Collegeno),
                new SqlParameter("@sts", sts)
               };
            var result = db.fn_ExecuteNonQuery("AD_SPPostStudentErpFee", parameters);
            if(result > 0)
            {
                success = new Success()
                {
                    Code = 300,
                    isSuccess =  true,
                    Message = "done"

            };
            }
            else
            {
                success = new Success()
                {
                    Code = 200,
                    isSuccess = false,
                    Message = "error"

                };
            }
           
           
            return Json(JsonConvert.SerializeObject(success), JsonRequestBehavior.AllowGet);
        }



    }
}