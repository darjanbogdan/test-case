using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Context
{
    /// <summary>
    /// User info contract.
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        IEnumerable<string> Roles { get; }
    }
}
