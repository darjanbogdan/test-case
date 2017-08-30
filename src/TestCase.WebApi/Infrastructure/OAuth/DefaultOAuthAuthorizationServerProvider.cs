using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using TestCase.Core.Query;
using TestCase.Service.Membership.Login;
using FluentValidation;

namespace TestCase.WebApi.Infrastructure.OAuth
{
    /// <summary>
    /// Default OAuth authorization server provider.
    /// </summary>
    /// <seealso cref="Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerProvider" />
    public class DefaultOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly Func<IQueryHandler<GetUserClaimsIdentityQuery, GetUserClaimsIdentityResult>> getUserClaimsHandlerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultOAuthAuthorizationServerProvider" /> class.
        /// </summary>
        /// <param name="getUserClaimsHandlerFactory">The handler factory.</param>
        public DefaultOAuthAuthorizationServerProvider(Func<IQueryHandler<GetUserClaimsIdentityQuery, GetUserClaimsIdentityResult>> getUserClaimsHandlerFactory)
        {
            this.getUserClaimsHandlerFactory = getUserClaimsHandlerFactory;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var query = new GetUserClaimsIdentityQuery
            {
                Password = context.Password,
                UserName = context.UserName
            };

            try
            {
                var result = await this.getUserClaimsHandlerFactory().HandleAsync(query);
                if (result != null)
                {
                    var ticket = new AuthenticationTicket(result.Identity, null);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                }
            }
            catch (ValidationException)
            {
                context.SetError("invalid_request", "The request is missing required parameters user name or password.");
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}