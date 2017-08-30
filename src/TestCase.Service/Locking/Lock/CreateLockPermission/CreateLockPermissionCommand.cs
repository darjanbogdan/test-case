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

namespace TestCase.Service.Locking.Lock.CreateLockPermission
{
    /// <summary>
    /// Create lock permission command.
    /// </summary>
    public class CreateLockPermissionCommand : IValidateModel, IAuthenticateModel, IAuthorizeModel, IPostLockEventModel
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockId { get; set; }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        string IValidateModel.Name => nameof(CreateLockPermissionCommand);

        /// <summary>
        /// Gets the permission group.
        /// </summary>
        string IAuthorizeModel.PermissionGroup => PermissionGroupMap.Lock;

        /// <summary>
        /// Gets the permission.
        /// </summary>
        string IAuthorizeModel.Permission => PermissionMap.Create;

        /// <summary>
        /// Gets the lock event type.
        /// </summary>
        string IPostLockEventModel.LockEventType => LockEventTypeMap.AccessGranted;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        Guid IPostLockEventModel.LockId => LockId;
    }
}
