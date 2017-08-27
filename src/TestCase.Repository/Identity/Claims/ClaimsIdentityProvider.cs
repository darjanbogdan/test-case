using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Model.Membership;
using TestCase.Repository.Identity.Claims.Contracts;

namespace TestCase.Repository.Identity.Claims
{
    /// <summary>
    /// Claims identity provider.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Identity.Providers.Contracts.IClaimsIdentityProvider" />
    public class ClaimsIdentityProvider : IClaimsIdentityProvider
    {
        private readonly UserManager<UserEntity, Guid> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsIdentityProvider"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public ClaimsIdentityProvider(UserManager<UserEntity, Guid> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Asynchronously gets the claims identity.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GetAsync(Account account)
        {
            const string authenticationType = "JWT";
            var user = new UserEntity
            {
                Email = account.Email,
                UserName = account.UserName,
                Id = account.UserId
            };

            return await this.userManager.CreateIdentityAsync(user, authenticationType);
        }
    }
}
