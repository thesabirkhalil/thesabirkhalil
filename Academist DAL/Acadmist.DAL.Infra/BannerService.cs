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
    public class BannerService : IBanner
    {
        private readonly DotPlusData _db;

        public BannerService(DotPlusData Database)
        {
            _db = Database;
        }
        public int AddBanner(Banner banner)
        {
            throw new NotImplementedException();
        }

        public Banner GetBanner(int BannerID)
        {
            throw new NotImplementedException();
        }

        public List<Banner> GetBanners(int CollegeID)
        {
            using (_db)
            {
                List<Banner> banners = new List<Banner>();
                var rdr = _db.fn_DataReader("EC_SPGetWebBanner",
                   new SqlParameter("@Clgid", CollegeID));
                while (rdr.Read())
                {
                    banners.Add(new Banner()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        Title = Convert.ToString(rdr["Title"]),
                        BannerImg = Convert.ToString(rdr["BannerImg"]),
                        TargetLink = Convert.ToString(rdr["TargetLink"]),
                        Startdate = Convert.ToDateTime(rdr["Startdate"]),
                        EndDate = Convert.ToDateTime(rdr["EndDate"]),
                        DisplayOrder = Convert.ToInt16(rdr["DisplayOrder"]),
                        sts = Convert.ToString(rdr["sts"]),
                        Edate = Convert.ToDateTime(rdr["Edate"])
                    });
                }
                return banners;
            }
        }

       

        public int UpdateBanner(Banner banner)
        {
            throw new NotImplementedException();
        }
    }
}
