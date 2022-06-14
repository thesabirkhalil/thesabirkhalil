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
    public class DemandDetailService : IDemandDetail
    {
        private readonly DotPlusData database;

        public DemandDetailService(DotPlusData Database)
        {
            database = Database;
        }
        public List<DemandDetailComponent> GetDemandDetails_Student(int DemandID, int StudentID)
        {
            var demandDetailList =new  List<DemandDetailComponent>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentID", StudentID),
                new SqlParameter("@DemandiID", DemandID)
            };
            var rdr = database.fn_DataReader("EC_SPGetDemandDetail_Studentas", parameters);
            while (rdr.Read())
            {
                demandDetailList.Add(new DemandDetailComponent()
                {
                    DemandID = Convert.IsDBNull(rdr["DemandID"]) ? (int?)null : Convert.ToInt32(rdr["DemandID"]),
                    ProgramName = Convert.ToString(rdr["ProgramName"]),
                    SemName = Convert.ToString(rdr["SemName"]),
                    AcadmicYear = Convert.ToString(rdr["AcadmicYear"]),
                    GeneratedMonth = Convert.ToString(rdr["GeneratedMonth"]),
                    GeneratedYear = Convert.IsDBNull(rdr["GeneratedYear"]) ? (int?)null : Convert.ToInt32(rdr["GeneratedYear"]),
                    Description = Convert.ToString(rdr["Description"]),
                    Fee = Convert.IsDBNull(rdr["Fee"]) ? (decimal?)null : Convert.ToDecimal(rdr["Fee"]),
                    PaidAmt = Convert.IsDBNull(rdr["PaidAmt"]) ? (decimal?)null : Convert.ToDecimal(rdr["PaidAmt"]),
                });
            }
            return demandDetailList;
        }
    }
}
