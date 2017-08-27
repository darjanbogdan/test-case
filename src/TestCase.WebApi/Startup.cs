using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestCase.DataAccess;
using TestCase.Repository;
using TestCase.Service;
using TestCase.WebApi.Infrastructure.DependencyInjection;
using TestCase.WebApi.Infrastructure.OAuth.Middlewares;
using TestCase.WebApi.Infrastructure.Owin.Middlewares;

[assembly: OwinStartup(typeof(TestCase.WebApi.Startup))]

namespace TestCase.WebApi
{
    /// <summary>
    /// Application startup.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            #region Container

            var container = DependencyInjectionContainerFactory.Create();

            DataAccessBootstrapper.Bootstrap(container);
            RepositoryBootstrapper.Bootstrap(container);
            ServiceBoostrapper.Bootstrap(container);
            WebApiBootstrapper.Bootstrap(container);

            container.RegisterWebApiControllers(config);

#if DEBUG
            container.Verify();
#endif

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            #endregion Container

            app.UseOwinContextExecutionScope(container);

            #region OAuth

            app.UseDefaultOAuthAuthorizationServer(container);
            app.UseDefaultOAuthBearerAuthentication(container);

            #endregion OAuth

            #region Web Api

            app.UseOwinContextProvider();

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            #endregion Web Api
        }
    }
}