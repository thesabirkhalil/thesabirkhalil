using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL
{
    public class Banner
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public int clgid { get; set; }
        public string Title { get; set; }
        public string BannerImg { get; set; }
        public string TargetLink { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public int DisplayOrder { get; set; }
        public string sts { get; set; }
        public DateTime Edate { get; set; }
    }
}
