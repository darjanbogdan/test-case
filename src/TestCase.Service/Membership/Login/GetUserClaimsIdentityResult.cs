using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Service.Membership.Login
{
    /// <summary>
    /// Get user claims identity result.
    /// </summary>
    public class GetUserClaimsIdentityResult
    {
        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        public ClaimsIdentity Identity { get; set; }
    }
}
