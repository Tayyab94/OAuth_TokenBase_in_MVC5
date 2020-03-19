using Microsoft.Owin.Security.OAuth;
using OuthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OuthApp.Providers
{
    public class OauthProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var db = new OauthContext())
            {
                if(db!=null)
                {
                    var user = db.ApiUsers.Where(x => x.UserName == context.UserName && x.Password == context.Password).FirstOrDefault();

                    if(user!=null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                        identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));

                        await Task.Run(() => context.Validated(identity));
                    }
                    else
                    {
                        context.SetError("Wrong Credential", "Provider User Name or Password is not Correct");
                    }
                }
                else
                {
                    context.SetError("Wrong Credential", "Provider User Name or Password is not Correct");
                }

                return;
            }
        }
    }
}