using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCase.WebApi.Infrastructure.Owin.Middlewares
{
    /// <summary>
    /// Owin context execution scope middleware.
    /// </summary>
    public static class OwinContextExecutionScopeMiddleware
    {
        /// <summary>
        /// Uses the owin context execution scope.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="container">The container.</param>
        public static void UseOwinContextExecutionScope(this IAppBuilder app, Container container)
        {
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next.Invoke();
                }
            });
        }
    }
}