using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using TestCase.Core.Context;
using TestCase.WebApi.Infrastructure.Owin.Providers.Contracts;

namespace TestCase.WebApi.Infrastructure.Context
{
    /// <summary>
    /// Request context.
    /// </summary>
    /// <seealso cref="TestCase.Core.Context.IExecutionContext" />
    public class RequestContext : IExecutionContext
    {
        private Lazy<IUserInfo> userInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        /// <param name="owinContextProvider">The owin context provider.</param>
        public RequestContext(IOwinContextProvider owinContextProvider)
        {
            this.userInfo = new Lazy<IUserInfo>(() => InitializeUserInfo(owinContextProvider.CurrentContext));
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        public IUserInfo UserInfo => this.userInfo.Value;

        private IUserInfo InitializeUserInfo(IOwinContext currentContext)
        {
            var userInfo = new ContextUserInfo();
            userInfo.IsAuthenticated = currentContext.Authentication.User.Identity.IsAuthenticated;
            if (userInfo.IsAuthenticated)
            {
                userInfo.UserName = currentContext.Authentication.User.Identity.Name;
                userInfo.UserId = new Guid(currentContext.Authentication.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                userInfo.Roles = currentContext.Authentication.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            }
            return userInfo;
        }

        private class ContextUserInfo : IUserInfo
        {
            public bool IsAuthenticated { get; set; }

            public IEnumerable<string> Roles { get; set; }

            public Guid UserId { get; set; }

            public string UserName { get; set; }
        }
    }
}