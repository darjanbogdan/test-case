using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;
using TestCase.DataAccess.Entities.Identity;

namespace TestCase.DataAccess.Entities.Permission
{
    /// <summary>
    /// Permission policy entity.
    /// </summary>
    /// <seealso cref="TestCase.DataAccess.Entities.Contracts.IEntity" />
    public class PermissionPolicyEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        public PermissionEntity Permission { get; set; }

        /// <summary>
        /// Gets or sets the permission group identifier.
        /// </summary>
        public Guid PermissionGroupId { get; set; }

        /// <summary>
        /// Gets or sets the permission group.
        /// </summary>
        public PermissionGroupEntity PermissionGroup { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public RoleEntity Role { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public UserEntity User { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}
