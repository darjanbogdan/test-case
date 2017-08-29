using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Auth
{
    /// <summary>
    /// Authorize model contract.
    /// </summary>
    public interface IAuthorizeModel
    {
        /// <summary>
        /// Gets the permission group.
        /// </summary>
        string PermissionGroup { get; }

        /// <summary>
        /// Gets the permission.
        /// </summary>
        string Permission { get; }
    }
}
