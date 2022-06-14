using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL
{
    public class NoticeBoard
    {
        public int id { get; set; }
        public int? UserId { get; set; }
        public int clgid { get; set; }
        public string NewsType { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string TargetLink { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? DispalyOrder { get; set; }
        public bool IsNew { get; set; }
        public string sts { get; set; }
        public DateTime? edate { get; set; }

    }
}
