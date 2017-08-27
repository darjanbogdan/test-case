using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCase.WebApi.Infrastructure.OAuth.OwinMiddlewares
{
    /// <summary>
    /// Default OAuth authorization server middleware.
    /// </summary>
    public static class DefaultOAuthAuthorizationServerMiddleware
    {
        /// <summary>
        /// Uses the default o authentication authorization server.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public static IAppBuilder UseDefaultOAuthAuthorizationServer(this IAppBuilder app, Container container)
        {
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                AuthenticationMode = AuthenticationMode.Active,
                AuthenticationType = "Bearer",
                AccessTokenFormat = container.GetInstance<ISecureDataFormat<AuthenticationTicket>>(),
                Provider = container.GetInstance<IOAuthAuthorizationServerProvider>()
            };
            return app.UseOAuthAuthorizationServer(options);
        }
    }
}