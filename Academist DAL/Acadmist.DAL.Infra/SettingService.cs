using Acadmist.BAL;
using Acadmist.BAL.Repository;
using Dotplus.Database.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.DAL.Infra
{
    public class SettingService : ISetting
    {
        private readonly DotPlusData db;

        public SettingService(DotPlusData db)
        {
            this.db = db;
        }
        public Setting GetSetting(int Collegeid)
        {
            var rdr = db.fn_DataReader("EC_SPGetSettings", new SqlParameter("@CollegeID", Collegeid));
            if (rdr.Read())
            {
                return new Setting()
                {
                    id = Convert.ToInt32(rdr["id"]),
                    CLGID = Convert.ToInt32(rdr["CLGID"]),
                    SMSGateway = Convert.ToString(rdr["SMSGateway"]),
                    OTPGateway = Convert.ToString(rdr["OTPGateway"]),
                    SMSDeliveryGateway = Convert.ToString(rdr["SMSDeliveryGateway"]),
                    SMSGatewaysecond = Convert.ToString(rdr["SMSGatewaysecond"]),
                    OTPGatewaysecond = Convert.ToString(rdr["OTPGatewaysecond"]),
                    WAGAteway = Convert.ToString(rdr["WAGAteway"]),
                    WAGatewayMedia = Convert.ToString(rdr["WAGatewayMedia"]),
                    DemandPrefix = Convert.ToString(rdr["DemandPrefix"]),
                    Mob_Replace_Test = Convert.ToString(rdr["Mob_Replace_Test"]),
                    MSG_Replace_txt = Convert.ToString(rdr["MSG_Replace_txt"]),
                    MSG_Replace_JobID = Convert.ToString(rdr["MSG_Replace_JobID"]),
                    SMSLanguage = Convert.ToString(rdr["SMSLanguage"]),
                    VoucherPrefix = Convert.ToString(rdr["VoucherPrefix"]),
                    acknowledgementFormat = Convert.ToString(rdr["acknowledgementFormat"]),
                    ReceiptFormat = Convert.ToString(rdr["ReceiptFormat"]),
                    EnqReceiptFormate = Convert.ToString(rdr["EnqReceiptFormate"]),
                    Stud_Walt_acknowFormat = Convert.ToString(rdr["Stud_Walt_acknowFormat"]),
                    stud_Walt_ReceiptFormat = Convert.ToString(rdr["stud_Walt_ReceiptFormat"]),
                    isAutoDemand = Convert.ToBoolean(rdr["isAutoDemand"]),
                    TCnoFormate = Convert.ToString(rdr["TCnoFormate"]),
                    isLateFine = Convert.ToBoolean(rdr["isLateFine"]),
                    LateFineDay = Convert.ToInt32(rdr["LateFineDay"]),
                    LateFineMode = Convert.ToString(rdr["LateFineMode"]),
                    LateFineHead = Convert.IsDBNull(rdr["LateFineHead"]) ? (int?)null : Convert.ToInt32(rdr["LateFineHead"]),
                    Labrary_MaxBookHoldDay = Convert.ToInt32(rdr["Labrary_MaxBookHoldDay"]),
                    PO_Limit = Convert.IsDBNull(rdr["PO_Limit"]) ? (decimal?)null : Convert.ToDecimal(rdr["PO_Limit"]),
                    IsOnlinePayment = Convert.ToBoolean(rdr["IsOnlinePayment"]),
                    IsliveClassAuto = Convert.ToBoolean(rdr["IsliveClassAuto"]),
                    IsSemChangeRequest = Convert.ToBoolean(rdr["IsSemChangeRequest"]),
                    isDECEDeatils = Convert.ToBoolean(rdr["isDECEDeatils"]),
                    isManualAttendanceDate = Convert.ToString(rdr["isManualAttendanceDate"]),
                    isApiAttendanceAllowed = Convert.ToBoolean(rdr["isApiAttendanceAllowed"]),
                    isOnlineExamRequest = Convert.ToBoolean(rdr["isOnlineExamRequest"]),
                    isMaterialApproval = Convert.ToBoolean(rdr["isMaterialApproval"]),
                    IsGoogleEducation = Convert.ToBoolean(rdr["IsGoogleEducation"]),
                    AttendancePercantage = Convert.IsDBNull(rdr["AttendancePercantage"]) ? (decimal?)null : Convert.ToDecimal(rdr["AttendancePercantage"]),
                    BillingMode = Convert.ToString(rdr["BillingMode"]),
                    isBulkPayment = Convert.ToBoolean(rdr["isBulkPayment"]),
                    isPlanHeadGroup = Convert.ToBoolean(rdr["isPlanHeadGroup"]),
                    EmpAttendanceShowMonths = Convert.IsDBNull(rdr["EmpAttendanceShowMonths"]) ? (int?)null : Convert.ToInt32(rdr["EmpAttendanceShowMonths"]),
                    isCompanyFeeFilter = Convert.ToBoolean(rdr["isCompanyFeeFilter"])
                };
            }
            else
                return new Setting();
        }

    }
}
