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
    public class SMSOutboxService : ISMSOutbox
    {
        private readonly DotPlusData db;

        public SMSOutboxService(DotPlusData db)
        {
            this.db = db;
        }
        public List<SMSOutbox> GetSMSOutboxes(int StudentID)
        {
            List<SMSOutbox> outboxes = new List<SMSOutbox>();
            var rdr  = db.fn_DataReader("EC_SPGetSMSOutboxByStudent", new SqlParameter("@StudentID", StudentID));
            while (rdr.Read())
            {
                outboxes.Add(new SMSOutbox()
                {
                    id = Convert.ToInt32(rdr["id"]),
                    SMSTYPE = Convert.ToString(rdr["SMSTYPE"]),
                    Clgid = Convert.ToInt32(rdr["Clgid"]),
                    userID = Convert.ToInt32(rdr["userID"]),
                    StudId = Convert.ToInt32(rdr["StudId"]),
                    Unicode = Convert.ToBoolean(rdr["Unicode"]),
                    sentToMobile = Convert.ToString(rdr["sentToMobile"]),
                    sentDateTime = Convert.IsDBNull(rdr["sentDateTime"]) ? (DateTime?)null: Convert.ToDateTime(rdr["sentDateTime"]),
                    SendMessage = Convert.ToString(rdr["SendMessage"]),
                    status = Convert.IsDBNull(rdr["status"]) ? (int?)null : Convert.ToInt32(rdr["status"]),
                    edate = Convert.ToDateTime(rdr["edate"]),
                    scheduleDateTime = Convert.IsDBNull(rdr["scheduleDateTime"]) ? (DateTime?)null : Convert.ToDateTime(rdr["scheduleDateTime"]),
                    StatusUpdateDateTime = Convert.IsDBNull(rdr["StatusUpdateDateTime"]) ? (DateTime?)null :  Convert.ToDateTime(rdr["StatusUpdateDateTime"]),
                    GatewayRemarks = Convert.ToString(rdr["GatewayRemarks"]),
                    errorCode = Convert.ToString(rdr["errorCode"]),
                    errorMessage = Convert.ToString(rdr["errorMessage"]),
                    jobId = Convert.ToString(rdr["jobId"]),
                    messageId = Convert.ToString(rdr["messageId"]),
                    deliveryStatus = Convert.ToString(rdr["deliveryStatus"]),
                    deliveryDate = Convert.IsDBNull(rdr["deliveryDate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["deliveryDate"]),
                    isRead_APP = Convert.ToBoolean(rdr["isRead_APP"]),
                    ReadDateTime = Convert.IsDBNull(rdr["ReadDateTime"]) ? (DateTime?)null : Convert.ToDateTime(rdr["ReadDateTime"]),
                });
            }
            return outboxes;
        }
    }
}
