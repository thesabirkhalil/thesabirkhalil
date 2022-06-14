using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acadmist.BAL;
using Acadmist.BAL.Repository;
using Dotplus.Database.StoreProcedure;

namespace Acadmist.DAL.Infra
{
    public class CollegeServices : ICollege
    {
        private readonly DotPlusData _db;

        public CollegeServices(DotPlusData Database)
        {
            _db = Database;
        }
        public int Create(College college)
        {
            throw new NotImplementedException();
        }

        public College GetCollege(string URLCode)
        {
            using (_db)
            {

                var rdr = _db.fn_DataReader("EC_SPGetCollegeByURLCode",
                   new SqlParameter("@URLCode", URLCode));
                if (rdr.Read())
                {
                    College college = new College()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        UnivID = Convert.ToInt32(rdr["UnivID"]),
                        URLCode = Convert.ToString(rdr["URLCode"]),
                        CollegeName = Convert.ToString(rdr["CollegeName"]),
                        Code = Convert.ToString(rdr["Code"]),
                        EmailID = Convert.ToString(rdr["EmailID"]),
                        ContactPerson = Convert.ToString(rdr["ContactPerson"]),
                        ContactNo = Convert.ToString(rdr["ContactNo"]),
                        Address = Convert.ToString(rdr["Address"]),
                        City = Convert.ToString(rdr["City"]),
                        Dist = Convert.ToString(rdr["Dist"]),
                        State = Convert.ToString(rdr["State"]),
                        Pincode = Convert.ToString(rdr["Pincode"]),
                        LogoURL = Convert.ToString(rdr["LogoURL"]),
                        ReportHeaderLogo = Convert.ToString(rdr["ReportHeaderLogo"]),
                        DomainName = Convert.ToString(rdr["DomainName"]),
                        CollegeImage = Convert.ToString(rdr["CollegeImage"]),
                        sts = Convert.ToString(rdr["sts"]),
                        Edate = Convert.ToDateTime(rdr["Edate"]),
                        PrivacyPolicyPage = Convert.ToString(rdr["PrivacyPolicyPage"]),
                        RefundSecurityPage = Convert.ToString(rdr["RefundSecurityPage"]),
                        TermsConditionPage = Convert.ToString(rdr["TermsConditionPage"]),
                        AboutUsPage = Convert.ToString(rdr["AboutUsPage"]),
                        AppThemeClr = Convert.ToString(rdr["AppThemeClr"])
                    };
                    return college;
                }
                else
                {
                    return null;
                }
            }
        }

        public College GetCollege(int CollageID)
        {
            using (_db)
            {

                var rdr = _db.fn_DataReader("EC_SPGetCollegeByID",
                   new SqlParameter("@id", CollageID));
                if (rdr.Read())
                {
                    College college = new College()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        UnivID = Convert.ToInt32(rdr["UnivID"]),
                        URLCode = Convert.ToString(rdr["URLCode"]),
                        CollegeName = Convert.ToString(rdr["CollegeName"]),
                        Code = Convert.ToString(rdr["Code"]),
                        EmailID = Convert.ToString(rdr["EmailID"]),
                        ContactPerson = Convert.ToString(rdr["ContactPerson"]),
                        ContactNo = Convert.ToString(rdr["ContactNo"]),
                        Address = Convert.ToString(rdr["Address"]),
                        City = Convert.ToString(rdr["City"]),
                        Dist = Convert.ToString(rdr["Dist"]),
                        State = Convert.ToString(rdr["State"]),
                        Pincode = Convert.ToString(rdr["Pincode"]),
                        LogoURL = Convert.ToString(rdr["LogoURL"]),
                        ReportHeaderLogo = Convert.ToString(rdr["ReportHeaderLogo"]),
                        DomainName = Convert.ToString(rdr["DomainName"]),
                        CollegeImage = Convert.ToString(rdr["CollegeImage"]),
                        sts = Convert.ToString(rdr["sts"]),
                        Edate = Convert.ToDateTime(rdr["Edate"]),
                        PrivacyPolicyPage = Convert.ToString(rdr["PrivacyPolicyPage"]),
                        RefundSecurityPage = Convert.ToString(rdr["RefundSecurityPage"]),
                        TermsConditionPage = Convert.ToString(rdr["TermsConditionPage"]),
                        AboutUsPage = Convert.ToString(rdr["AboutUsPage"]),
                        AppThemeClr = Convert.ToString(rdr["AppThemeClr"])
                    };
                    return college;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<College> GetColleges(int UniversityID)
        {
            using (_db)
            {
                List<College> colleges = new List<College>();
                var rdr = _db.fn_DataReader("EC_SPGetCollegeByUnivID",
                   new SqlParameter("@UnivID", UniversityID));
                while (rdr.Read())
                {
                    colleges.Add(new College()
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        UnivID = Convert.ToInt32(rdr["UnivID"]),
                        URLCode = Convert.ToString(rdr["URLCode"]),
                        CollegeName = Convert.ToString(rdr["CollegeName"]),
                        Code = Convert.ToString(rdr["Code"]),
                        EmailID = Convert.ToString(rdr["EmailID"]),
                        ContactPerson = Convert.ToString(rdr["ContactPerson"]),
                        ContactNo = Convert.ToString(rdr["ContactNo"]),
                        Address = Convert.ToString(rdr["Address"]),
                        City = Convert.ToString(rdr["City"]),
                        Dist = Convert.ToString(rdr["Dist"]),
                        State = Convert.ToString(rdr["State"]),
                        Pincode = Convert.ToString(rdr["Pincode"]),
                        LogoURL = Convert.ToString(rdr["LogoURL"]),
                        ReportHeaderLogo = Convert.ToString(rdr["ReportHeaderLogo"]),
                        DomainName = Convert.ToString(rdr["DomainName"]),
                        CollegeImage = Convert.ToString(rdr["CollegeImage"]),
                        sts = Convert.ToString(rdr["sts"]),
                        Edate = Convert.ToDateTime(rdr["Edate"]),
                        PrivacyPolicyPage = Convert.ToString(rdr["PrivacyPolicyPage"]),
                        RefundSecurityPage = Convert.ToString(rdr["RefundSecurityPage"]),
                        TermsConditionPage = Convert.ToString(rdr["TermsConditionPage"]),
                        AboutUsPage = Convert.ToString(rdr["AboutUsPage"]),
                        AppThemeClr = Convert.ToString(rdr["AppThemeClr"])
                    });
                }
                return colleges;
            }
        }
    }
}
