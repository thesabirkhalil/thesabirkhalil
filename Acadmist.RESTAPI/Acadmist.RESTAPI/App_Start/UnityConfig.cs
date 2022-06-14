using Acadmist.BAL.Repository;
using Acadmist.DAL.Authentication;
using Acadmist.DAL.Demand;
using Acadmist.DAL.Infra;
using Acadmist.RESTAPI.Models;
using Acadmist.RESTAPI.OwinToken;
using Dotplus.Database.StoreProcedure;
using Dotplus.Database.StoreProcedure.Single;
using System.Security.Claims;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Acadmist.RESTAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthentication, AuthenticationService>();
            container.RegisterType<ICollege, CollegeServices>();
            container.RegisterType<INoticeBoard, NoticeBoardService>();
            container.RegisterType<IBanner, BannerService>();
            container.RegisterType<IDemandStudent, DemandStudentService>();
            container.RegisterType<ISMSOutbox, SMSOutboxService>();
            container.RegisterType<ISetting, SettingService>();
            container.RegisterType<ICompany, CompanyService>();
            container.RegisterType<IDemandDetail, DemandDetailService>();
            container.RegisterType<vm_Response, vm_Response>();
            container.RegisterInstance<DotPlusData>(SingletonDatabase.GetInstance("DBCS"));
            container.RegisterType<TokenAccess, TokenAccess>();
            Startup.IoC = container;
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}