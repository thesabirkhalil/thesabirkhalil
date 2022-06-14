using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface ICollege
    {
        int Create(College college);
        College GetCollege(string URLCode);
        College GetCollege(int CollageID);
        List<College> GetColleges(int UniversityID);
    }
}
