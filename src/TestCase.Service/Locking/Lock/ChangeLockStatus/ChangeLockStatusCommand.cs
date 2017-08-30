using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Validation;
using TestCase.Service.Security.Maps;

namespace TestCase.Service.Locking.Lock.ChangeLockStatus
{
    /// <summary>
    /// Change lock status command.
    /// </summary>
    public class ChangeLockStatusCommand : IAuthenticateModel, IAuthorizeModel
    {
        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChangeLockStatusCommand"/> is locked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets the permission group.
        /// </summary>
        string IAuthorizeModel.PermissionGroup => PermissionGroupMap.Lock;

        /// <summary>
        /// Gets the permission.
        /// </summary>
        string IAuthorizeModel.Permission => PermissionMap.Update;
    }
}
