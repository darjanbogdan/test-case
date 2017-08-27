using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TestCase.Core.Command;
using TestCase.Core.Context;
using TestCase.Core.Query;
using TestCase.WebApi.Infrastructure.Context;
using TestCase.WebApi.Infrastructure.OAuth;
using TestCase.WebApi.Infrastructure.Owin.Providers;
using TestCase.WebApi.Infrastructure.Owin.Providers.Contracts;

namespace TestCase.WebApi
{
    /// <summary>
    /// Web api bootstrapper.
    /// </summary>
    public static class WebApiBootstrapper
    {
        /// <summary>
        /// Bootstraps the web api layer.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Bootstrap(Container container)
        {
            container.Register<IOAuthAuthorizationServerProvider, DefaultOAuthAuthorizationServerProvider>();
            container.Register<ISecureDataFormat<AuthenticationTicket>>(() =>
            {
                var tokenIssuer = ConfigurationManager.AppSettings["TokenIssuer"];
                var tokenAudience = ConfigurationManager.AppSettings["TokenAudience"];
                var tokenAudienceSecret = ConfigurationManager.AppSettings["TokenAudienceSecret"];
                return new DefaultJwtFormat(tokenIssuer, tokenAudience, tokenAudienceSecret);
            });
            container.RegisterSingleton<IOwinContextProvider, OwinContextProvider>();
            container.Register<IExecutionContext, RequestContext>(Lifestyle.Scoped);
        }
    }
}