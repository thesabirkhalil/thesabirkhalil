using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL
{
    public class Company
    {
        public int id { get; set; }
        public int UsrID { get; set; }
        public int ClgID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyPrefix { get; set; }
        public string ComapnyFeeType { get; set; }
        public string ContactPersone { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Dist { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string sts { get; set; }
        public bool IsComapnyFeeTypeShow { get; set; }
        public DateTime Edate { get; set; }
    }
}
