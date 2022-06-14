using Acadmist.BAL;
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
    public class CompanyService : ICompany
    {
        private readonly DotPlusData db;

        public CompanyService(DotPlusData db)
        {
            this.db = db;
        }
        public List<Company> GetCompanies(int CollegeID)
        {
            List<Company> companies = new List<Company>();
            var rdr = db.fn_DataReader("EC_SPGetCompanyList", new SqlParameter("@CollegeID", CollegeID));
            while (rdr.Read())
            {
                companies.Add(new Company()
                {
                    id = Convert.ToInt32(rdr["id"]),
                    UsrID = Convert.ToInt32(rdr["UsrID"]),
                    ClgID = Convert.ToInt32(rdr["ClgID"]),
                    CompanyName = Convert.ToString(rdr["CompanyName"]),
                    CompanyCode = Convert.ToString(rdr["CompanyCode"]),
                    CompanyPrefix = Convert.ToString(rdr["CompanyPrefix"]),
                    ComapnyFeeType = Convert.ToString(rdr["ComapnyFeeType"]),
                    ContactPersone = Convert.ToString(rdr["ContactPersone"]),
                    ContactNo = Convert.ToString(rdr["ContactNo"]),
                    EmailID = Convert.ToString(rdr["EmailID"]),
                    Address = Convert.ToString(rdr["Address"]),
                    City = Convert.ToString(rdr["City"]),
                    Dist = Convert.ToString(rdr["Dist"]),
                    State = Convert.ToString(rdr["State"]),
                    Pincode = Convert.ToString(rdr["Pincode"]),
                    sts = Convert.ToString(rdr["sts"]),
                    IsComapnyFeeTypeShow = Convert.ToBoolean(rdr["IsComapnyFeeTypeShow"]),
                    Edate = Convert.ToDateTime(rdr["Edate"]),
                });
            }
            return companies;
        }
    }
}
