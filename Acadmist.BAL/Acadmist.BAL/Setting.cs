using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL
{
    public class Setting
    {
        public int id { get; set; }
        public int CLGID { get; set; }
        public string SMSGateway { get; set; }
        public string OTPGateway { get; set; }
        public string SMSDeliveryGateway { get; set; }
        public string SMSGatewaysecond { get; set; }
        public string OTPGatewaysecond { get; set; }
        public string WAGAteway { get; set; }
        public string WAGatewayMedia { get; set; }
        public string DemandPrefix { get; set; }
        public string Mob_Replace_Test { get; set; }
        public string MSG_Replace_txt { get; set; }
        public string MSG_Replace_JobID { get; set; }
        public string SMSLanguage { get; set; }
        public string VoucherPrefix { get; set; }
        public string acknowledgementFormat { get; set; }
        public string ReceiptFormat { get; set; }
        public string EnqReceiptFormate { get; set; }
        public string Stud_Walt_acknowFormat { get; set; }
        public string stud_Walt_ReceiptFormat { get; set; }
        public bool isAutoDemand { get; set; }
        public string TCnoFormate { get; set; }
        public bool isLateFine { get; set; }
        public int LateFineDay { get; set; }
        public string LateFineMode { get; set; }
        public int? LateFineHead { get; set; }
        public int Labrary_MaxBookHoldDay { get; set; }
        public decimal? PO_Limit { get; set; }
        public bool IsOnlinePayment { get; set; }
        public bool IsliveClassAuto { get; set; }
        public bool IsSemChangeRequest { get; set; }
        public bool isDECEDeatils { get; set; }
        public string isManualAttendanceDate { get; set; }
        public bool isApiAttendanceAllowed { get; set; }
        public bool isOnlineExamRequest { get; set; }
        public bool isMaterialApproval { get; set; }
        public bool IsGoogleEducation { get; set; }
        public decimal? AttendancePercantage { get; set; }
        public string BillingMode { get; set; }
        public bool isBulkPayment { get; set; }
        public bool isPlanHeadGroup { get; set; }
        public int? EmpAttendanceShowMonths { get; set; }
        public bool isCompanyFeeFilter { get; set; }
    }
}
