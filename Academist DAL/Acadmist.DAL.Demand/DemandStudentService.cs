using Acadmist.BAL.Component;
using Acadmist.BAL.Repository;
using Dotplus.Database.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.DAL.Demand
{
    public class DemandStudentService : IDemandStudent
    {
        private readonly DotPlusData database;

        public DemandStudentService(DotPlusData Database)
        {
            database = Database;
        }

        public List<DemandListComponent> GetFeeDue(int StudentId)
        {
            List<DemandListComponent> demandListComponents = new List<DemandListComponent>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudID", StudentId)
            };
            var rdr = database.fn_DataReader("EC_SPGetDemandList_Student", parameters);
            while (rdr.Read())
            {
                demandListComponents.Add(new DemandListComponent()
                {
                    DemandNo = rdr["DemandNo"].ToString(),
                    CompanyID = Convert.IsDBNull(rdr["CompanyID"]) ? (int?)null : Convert.ToInt32(rdr["CompanyID"]),
                    GeneratedMonth = rdr["GeneratedMonth"].ToString(),
                    GeneratedYear = rdr["GeneratedYear"].ToString(),
                    id = Convert.ToInt32(rdr["id"]),
                    NetAmount = Convert.ToDecimal(rdr["NetAmount"]),
                    PaidAmount = Convert.ToDecimal(rdr["PaidAmount"]),
                    TotalDiscount = Convert.ToDecimal(rdr["TotalDiscount"]),
                    StudID = Convert.ToInt32(rdr["StudID"]),
                });
            }
            return demandListComponents;
        }

        public List<PaymentReceiptComponent> GetPaymentReceipt(int StudentID)
        {
            List<PaymentReceiptComponent> paymentReceipts = new List<PaymentReceiptComponent>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", StudentID)
            };
            var rdr = database.fn_DataReader("EC_SPGetPaymentReceipt_Student", parameters);
            while (rdr.Read())
            {
                paymentReceipts.Add(new PaymentReceiptComponent()
                {
                    PaymentNo = Convert.ToString(rdr["PaymentNo"]),
                    acknowledgementCode = Convert.ToString(rdr["acknowledgementCode"]),
                    sts = Convert.ToString(rdr["sts"]),
                    PaidAmount = Convert.ToDecimal(rdr["PaidAmount"]),
                    Edate = Convert.ToDateTime(rdr["Edate"]),
                    id = Convert.ToInt32(rdr["id"]),
                    StudentID = Convert.ToInt32(rdr["StudentID"]),
                });
            }
            return paymentReceipts;
        }
    }
}
