using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Validation;
using TestCase.Service.Security.Maps;

namespace TestCase.Service.Locking.Lock.ChangeStatus
{
    /// <summary>
    /// Change stauts command.
    /// </summary>
    public class ChangeStatusCommand : IValidateModel, IAuthenticateModel, IAuthorizeModel
    {
        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChangeStatusCommand"/> is locked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        string IValidateModel.Name => nameof(ChangeStatusCommand);

        /// <summary>
        /// Gets the owner identifier.
        /// </summary>
        Guid? IAuthorizeModel.OwnerId => this.UserId;

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
