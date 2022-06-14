using Acadmist.BAL.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Acadmist.RESTAPI.OwinToken
{
    public class AuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthentication authentication;

        public AuthorizationServiceProvider(IAuthentication  authentication)
        {
            this.authentication = authentication;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var form = await context.Request.ReadFormAsync();
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var LoginUser = authentication.LoginWithPassword(context.UserName, form["UserType"], context.Password);
            if (LoginUser != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, LoginUser.UserType));
                identity.AddClaim(new Claim("username", LoginUser.Username));
                identity.AddClaim(new Claim("Name", LoginUser.Name));
                identity.AddClaim(new Claim("MobileNo", LoginUser.MobileNo));
                identity.AddClaim(new Claim("collegeID", LoginUser.ClgID.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, LoginUser.id.ToString()));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid_Grant", "Provided username and password is invalid");
                return;
            }

        }
    }
}