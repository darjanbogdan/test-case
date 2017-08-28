using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Model.Security
{
    /// <summary>
    /// Permission policy.
    /// </summary>
    public class PermissionPolicy
    {
        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the permission group identifier.
        /// </summary>
        public Guid PermissionGroupId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public Guid? UserId { get; set; }
    }
}
