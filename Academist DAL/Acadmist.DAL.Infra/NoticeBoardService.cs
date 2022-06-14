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
    public class NoticeBoardService : INoticeBoard
    {
        private readonly DotPlusData _db;
        public NoticeBoardService(DotPlusData Database)
        {
            _db = Database;
        }
        public int CreateNotice(NoticeBoard noticeBoard)
        {
            throw new NotImplementedException();
        }

        public int DeleteNotice(NoticeBoard noticeBoard)
        {
            throw new NotImplementedException();
        }

        public List<NoticeBoard> GetActiveNotice(int CollegeID)
        {
            using (_db)
            {
                List<NoticeBoard> noticeBoards = new List<NoticeBoard>();
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@Clgid", CollegeID)
                };
                var rdr = _db.fn_DataReader("EC_SPGetActiveNoticeBoard",
                   parameter);
                while (rdr.Read())
                {
                    noticeBoards.Add(new NoticeBoard()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        UserId = Convert.IsDBNull(rdr["UserId"]) ? (int?)null : Convert.ToInt32(rdr["UserId"]),
                        clgid = Convert.ToInt32(rdr["clgid"]),
                        NewsType = Convert.ToString(rdr["NewsType"]),
                        Title = Convert.ToString(rdr["Title"]),
                        SubTitle = Convert.ToString(rdr["SubTitle"]),
                        TargetLink = Convert.ToString(rdr["TargetLink"]),
                        Startdate = Convert.IsDBNull(rdr["Startdate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["Startdate"]),
                        Enddate = Convert.IsDBNull(rdr["Enddate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["Enddate"]),
                        DispalyOrder = Convert.IsDBNull(rdr["DispalyOrder"]) ? (int?)null : Convert.ToInt32(rdr["DispalyOrder"]),
                        IsNew = Convert.ToBoolean(rdr["IsNew"]),
                        sts = Convert.ToString(rdr["sts"]),
                        edate = Convert.IsDBNull(rdr["edate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["edate"]),
                    });
                }
                return noticeBoards;
            }
        }

        public List<NoticeBoard> GetActiveNotice(int CollegeID, string NewsType)
        {
            using (_db)
            {
                List<NoticeBoard> noticeBoards = new List<NoticeBoard>();
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@Clgid", CollegeID),
                    new SqlParameter("@NewsType", NewsType)
                };
                var rdr = _db.fn_DataReader("EC_SPGetActiveNoticeBoard",
                   parameter);
                while (rdr.Read())
                {
                    noticeBoards.Add(new NoticeBoard()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        UserId = Convert.IsDBNull(rdr["UserId"]) ? (int?)null : Convert.ToInt32(rdr["UserId"]),
                        clgid = Convert.ToInt32(rdr["clgid"]),
                        NewsType = Convert.ToString(rdr["NewsType"]),
                        Title = Convert.ToString(rdr["Title"]),
                        SubTitle = Convert.ToString(rdr["SubTitle"]),
                        TargetLink = Convert.ToString(rdr["TargetLink"]),
                        Startdate = Convert.IsDBNull(rdr["Startdate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["Startdate"]),
                        Enddate = Convert.IsDBNull(rdr["Enddate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["Enddate"]),
                        DispalyOrder = Convert.IsDBNull(rdr["DispalyOrder"]) ? (int?)null : Convert.ToInt32(rdr["DispalyOrder"]),
                        IsNew = Convert.ToBoolean(rdr["IsNew"]),
                        sts = Convert.ToString(rdr["sts"]),
                        edate = Convert.IsDBNull(rdr["edate"]) ? (DateTime?)null : Convert.ToDateTime(rdr["edate"]),
                    });
                }
                return noticeBoards;
            }
        }

        public List<NoticeBoard> GetAllNotice(int CollegeID)
        {
            throw new NotImplementedException();
        }

        public NoticeBoard GetNotice(int NoticeBoardID)
        {
            throw new NotImplementedException();
        }

        public int UpdateNotice(NoticeBoard noticeBoard)
        {
            throw new NotImplementedException();
        }
    }
}
