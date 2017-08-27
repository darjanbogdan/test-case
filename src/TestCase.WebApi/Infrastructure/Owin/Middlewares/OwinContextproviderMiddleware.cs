using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace TestCase.WebApi.Infrastructure.Owin.Middlewares
{
    /// <summary>
    /// Owin context provider middleware.
    /// </summary>
    public static class OwinContextProviderMiddleware
    {
        /// <summary>
        /// Uses the owin context provider.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseOwinContextProvider(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                CallContext.LogicalSetData("IOwinContext", context);
                await next();
            });
        }
    }
}