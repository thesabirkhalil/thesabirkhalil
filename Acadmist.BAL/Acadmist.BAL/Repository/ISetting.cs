using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface ISetting
    {
        Setting GetSetting(int Collegeid);
    }
}
