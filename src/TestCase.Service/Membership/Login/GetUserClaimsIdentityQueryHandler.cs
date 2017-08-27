using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Query;
using TestCase.Repository.Identity.Claims.Contracts;
using TestCase.Repository.Membership.Contracts;

namespace TestCase.Service.Membership.Login
{
    /// <summary>
    /// Get user claims identity query handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Query.IQueryHandler{TestCase.Service.Membership.Login.GetUserClaimsIdentityResult, TestCase.Service.Membership.Login.GetUserClaimsIdentityQuery}" />
    public class GetUserClaimsIdentityQueryHandler : IQueryHandler<GetUserClaimsIdentityQuery, GetUserClaimsIdentityResult>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IClaimsIdentityProvider claimsIdentityProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserClaimsIdentityQueryHandler"/> class.
        /// </summary>
        /// <param name="claimsIdentityProvider">The claims identity provider.</param>
        public GetUserClaimsIdentityQueryHandler(IAccountRepository accountRepository, IClaimsIdentityProvider claimsIdentityProvider)
        {
            this.accountRepository = accountRepository;
            this.claimsIdentityProvider = claimsIdentityProvider;
        }

        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<GetUserClaimsIdentityResult> HandleAsync(GetUserClaimsIdentityQuery query)
        {
            var account = await this.accountRepository.GetAsync(query.UserName, query.Password);
            if (account != null)
            {
                var claimsIdentity = await this.claimsIdentityProvider.GetAsync(account);
                return new GetUserClaimsIdentityResult
                {
                    Identity = claimsIdentity
                };
            }
            return null;
        }
    }
}
