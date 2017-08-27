using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCase.WebApi.Infrastructure.OAuth.Middlewares
{
    /// <summary>
    /// Default OAuth bearer authentication middleware.
    /// </summary>
    public static class DefaultOAuthBearerAuthentication
    {
        /// <summary>
        /// Uses the default OAuth bearer authentication.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public static IAppBuilder UseDefaultOAuthBearerAuthentication(this IAppBuilder app, Container container)
        {
            var options = new OAuthBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AuthenticationType = "Bearer",
                AccessTokenFormat = container.GetInstance<ISecureDataFormat<AuthenticationTicket>>(),
            };
            return app.UseOAuthBearerAuthentication(options);
        }
    }
}