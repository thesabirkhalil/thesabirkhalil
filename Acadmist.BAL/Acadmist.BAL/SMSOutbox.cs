using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL
{
    public class SMSOutbox
    {
        public int id { get; set; }
        public string SMSTYPE { get; set; }
        public int Clgid { get; set; }
        public int userID { get; set; }
        public int? StudId { get; set; }
        public bool Unicode { get; set; }
        public string sentToMobile { get; set; }
        public DateTime? sentDateTime { get; set; }
        public string SendMessage { get; set; }
        public int? status { get; set; }
        public DateTime edate { get; set; }
        public DateTime? scheduleDateTime { get; set; }
        public DateTime? StatusUpdateDateTime { get; set; }
        public string GatewayRemarks { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string jobId { get; set; }
        public string messageId { get; set; }
        public string deliveryStatus { get; set; }
        public DateTime? deliveryDate { get; set; }
        public bool isRead_APP { get; set; }
        public DateTime? ReadDateTime { get; set; }

    }
}
