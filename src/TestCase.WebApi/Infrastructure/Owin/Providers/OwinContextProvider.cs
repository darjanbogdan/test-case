using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using TestCase.WebApi.Infrastructure.Owin.Providers.Contracts;

namespace TestCase.WebApi.Infrastructure.Owin.Providers
{
    /// <summary>
    /// Owin context provider.
    /// </summary>
    /// <seealso cref="TestCase.WebApi.Infrastructure.Owin.Providers.Contracts.IOwinContextProvider" />
    public class OwinContextProvider : IOwinContextProvider
    {
        /// <summary>
        /// Gets the current Owin context.
        /// </summary>
        public IOwinContext CurrentContext
        {
            get
            {
                return (IOwinContext)CallContext.LogicalGetData("IOwinContext");
            }
        }
    }
}