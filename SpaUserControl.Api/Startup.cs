using Microsoft.Owin.Security.OAuth;
using Owin;
using SpaUserControl.Api.Helpers;
using SpaUserControl.domain.Contracts.Services;
using SpaUserControl.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace SpaUserControl.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolver(container);

            ConfigureWebApi(config);
            ConfigureOAuth(app, container.Resolve<IUserService>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute
                (
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

        }

        public void ConfigureOAuth(IAppBuilder app, IUserService service)
        {
            OAuthAuthorizationServerOptions authorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider(service)

            };


            //Token Generation
            app.UseOAuthAuthorizationServer(authorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}