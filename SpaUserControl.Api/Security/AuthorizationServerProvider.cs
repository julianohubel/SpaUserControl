using Microsoft.Owin.Security.OAuth;
using SpaUserControl.domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SpanUserControl.common.Resources;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace SpaUserControl.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserService _service;

        public AuthorizationServerProvider(IUserService service)
        {
            _service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            //return base.ValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Acess-Control-Allow-Origin", new string[] { "*" });

            try
            {
                var user = _service.Authenticate(context.UserName, context.Password);
                if(user == null)
                {
                    context.SetError("invalid_grant", Erros.InvalidCredentials);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);


                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch (Exception ex)
            {

                context.SetError("invalid_grant", Erros.InvalidCredentials);
            }

            //return base.GrantResourceOwnerCredentials(context);
        }

    }
}