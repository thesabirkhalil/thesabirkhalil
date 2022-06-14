using Acadmist.BAL.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface IDemandDetail
    {
        List<DemandDetailComponent> GetDemandDetails_Student(int DemandID, int StudentID);
    }
}
