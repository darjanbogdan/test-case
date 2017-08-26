using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Auth
{
    /// <summary>
    /// Authorize contract.
    /// </summary>
    public interface IAuthorize
    {
        /// <summary>
        /// Gets the owner identifier.
        /// </summary>
        Guid? OwnerId { get; }

        /// <summary>
        /// Gets the permission section.
        /// </summary>
        string PermissionSection { get; }

        /// <summary>
        /// Gets the permission.
        /// </summary>
        string Permission { get; }
    }
}
