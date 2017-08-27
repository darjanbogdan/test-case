using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCase.WebApi.Infrastructure.Owin.Providers.Contracts
{
    /// <summary>
    /// Owin context provider contract.
    /// </summary>
    public interface IOwinContextProvider
    {
        /// <summary>
        /// Gets the current Owin context.
        /// </summary>
        IOwinContext CurrentContext { get; }
    }
}