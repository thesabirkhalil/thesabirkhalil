using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Component
{
    public class DemandDetailComponent
    {
        public int? DemandID { get; set; }
        public string ProgramName { get; set; }
        public string SemName { get; set; }
        public string AcadmicYear { get; set; }
        public string GeneratedMonth { get; set; }
        public int? GeneratedYear { get; set; }
        public string Description { get; set; }
        public decimal? Fee { get; set; }
        public decimal? PaidAmt { get; set; }
    }
}
