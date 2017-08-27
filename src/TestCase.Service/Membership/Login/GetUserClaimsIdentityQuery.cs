using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Query;

namespace TestCase.Service.Membership.Login
{
    /// <summary>
    /// Get user claims identity query.
    /// </summary>
    public class GetUserClaimsIdentityQuery : IQuery<GetUserClaimsIdentityResult>
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
