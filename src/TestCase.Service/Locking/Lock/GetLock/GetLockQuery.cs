using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Query;
using TestCase.Core.Validation;
using TestCase.Service.Security.Maps;

namespace TestCase.Service.Locking.Lock.GetLock
{
    /// <summary>
    /// Get lock query.
    /// </summary>
    /// <seealso cref="TestCase.Core.Query.IQuery{TestCase.Service.Locking.Lock.Get.GetLockResult}" />
    public class GetLockQuery : IQuery<GetLockResult>, IValidateModel, IAuthenticateModel, IAuthorizeModel
    {
        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockId { get; set; }

        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        string IValidateModel.Name => nameof(GetLockQuery);

        /// <summary>
        /// Gets the permission group.
        /// </summary>
        string IAuthorizeModel.PermissionGroup => PermissionGroupMap.Lock;

        /// <summary>
        /// Gets the permission.
        /// </summary>
        string IAuthorizeModel.Permission => PermissionMap.Read;
    }
}
