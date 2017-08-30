using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Validation;
using TestCase.Service.Locking.Events.Contracts;
using TestCase.Service.Locking.Maps;
using TestCase.Service.Security.Maps;

namespace TestCase.Service.Locking.Lock.DeleteLockPermission
{
    /// <summary>
    /// Delete lock permission command.
    /// </summary>
    public class DeleteLockPermissionCommand : IValidateModel, IAuthenticateModel, IAuthorizeModel, IPostLockEventModel
    {
        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockPermissionId { get; set; }

        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockId { get; set; }

        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        string IValidateModel.Name => nameof(DeleteLockPermissionCommand);

        /// <summary>
        /// Gets the permission group.
        /// </summary>
        string IAuthorizeModel.PermissionGroup => PermissionGroupMap.Lock;

        /// <summary>
        /// Gets the permission.
        /// </summary>
        string IAuthorizeModel.Permission => PermissionMap.Update;

        /// <summary>
        /// Gets the lock event type.
        /// </summary>
        string IPostLockEventModel.LockEventType => LockEventTypeMap.AccessProhibited;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        Guid IPostLockEventModel.LockId => LockId;
    }
}
