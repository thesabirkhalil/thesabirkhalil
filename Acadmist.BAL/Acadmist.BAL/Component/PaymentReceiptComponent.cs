using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Component
{
    public class PaymentReceiptComponent
    {
        public string PaymentNo { get; set; }
        public string acknowledgementCode { get; set; }
        public string sts { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime Edate { get; set; }
        public int id { get; set; }
        public int StudentID { get; set; }
    }
}
