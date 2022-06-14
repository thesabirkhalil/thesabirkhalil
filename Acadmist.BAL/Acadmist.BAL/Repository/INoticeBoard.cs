using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface INoticeBoard
    {
        List<NoticeBoard> GetAllNotice(int CollegeID);
        List<NoticeBoard> GetActiveNotice(int CollegeID);
        List<NoticeBoard> GetActiveNotice(int CollegeID, string NewsType);
        NoticeBoard GetNotice(int NoticeBoardID);
        int CreateNotice(NoticeBoard noticeBoard);
        int UpdateNotice(NoticeBoard noticeBoard);
        int DeleteNotice(NoticeBoard noticeBoard);

    }
}
