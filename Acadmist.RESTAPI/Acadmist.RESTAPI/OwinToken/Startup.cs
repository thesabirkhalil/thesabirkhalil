using Acadmist.BAL.Repository;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Unity;

[assembly: OwinStartup(typeof(Acadmist.RESTAPI.OwinToken.Startup))]

namespace Acadmist.RESTAPI.OwinToken
{
    public class Startup
    {
        public static UnityContainer IoC { get; set; }
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);
            var provider = new AuthorizationServiceProvider(IoC.Resolve<IAuthentication>());
            OAuthAuthorizationServerOptions serverOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = provider
            };
            app.UseOAuthAuthorizationServer(serverOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);

        }
    }
}
