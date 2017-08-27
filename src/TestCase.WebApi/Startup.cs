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
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            DataAccessBootstrapper.Bootstrap(container);
            RepositoryBootstrapper.Bootstrap(container);
            ServiceBoostrapper.Bootstrap(container);

            HttpConfiguration httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            container.RegisterWebApiControllers(httpConfig);

            httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            container.Verify();

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }
    }
}