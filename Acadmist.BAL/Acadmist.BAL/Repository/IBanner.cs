using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadmist.BAL.Repository
{
    public interface IBanner
    {
        int AddBanner(Banner banner);
        int UpdateBanner(Banner banner);
        List<Banner> GetBanners(int CollegeID);
        Banner GetBanner(int BannerID);
    }
}
