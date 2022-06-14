using Acadmist.BAL;
using Acadmist.BAL.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acadmist.RESTAPI.Models
{
    public class DemandList_StudentView
    {
        public List<DemandListComponent> demandLists { get; set; }
        public List<Company> Companies { get; set; }
    }
}