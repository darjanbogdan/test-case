using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Membership;

namespace TestCase.Repository.Identity.Claims.Contracts
{
    /// <summary>
    /// Claims identity provider.
    /// </summary>
    public interface IClaimsIdentityProvider
    {
        /// <summary>
        /// Asynchronously gets the claims identity.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<ClaimsIdentity> GetAsync(User user);
    }
}
