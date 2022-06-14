using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Component
{
    public class DemandListComponent
    {
        public int id { get; set; }
        public int? CompanyID { get; set; }
        public string DemandNo { get; set; }
        public string GeneratedMonth { get; set; }
        public string GeneratedYear { get; set; }
        public int StudID { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PaidAmount { get; set; }

    }
}
