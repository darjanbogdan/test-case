using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;

namespace TestCase.Repository.Locking.Contracts
{
    /// <summary>
    /// Lock repository contract.
    /// </summary>
    public interface ILockRepository
    {
        /// <summary>
        /// Asynchronously inserts the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        Task InsertLockAsync(Lock @lock);

        /// <summary>
        /// Asynchronously gets the lock.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        Task<Lock> GetLockAsync(Guid lockId);

        /// <summary>
        /// Asynchronously updates the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        Task UpdateLockAsync(Lock @lock);

        /// <summary>
        /// Asynchronously inserts the lock location.
        /// </summary>
        /// <param name="lockLocation">The lock location.</param>
        /// <returns></returns>
        Task InsertLockLocationAsync(LockLocation lockLocation);

        /// <summary>
        /// Asynchronously deletes the lock permission.
        /// </summary>
        /// <param name="lockPermissionId">The lock permission identifier.</param>
        /// <returns></returns>
        Task DeleteLockPermissionAsync(Guid lockPermissionId);

        /// <summary>
        /// Asynchronously gets the lock permission.
        /// </summary>
        /// <param name="lockPermissionId">The lock permission identifier.</param>
        /// <returns></returns>
        Task<LockPermissionPolicy> GetLockPermissionAsync(Guid lockPermissionId);

        /// <summary>
        /// Asynchronously inserts the lock permission policy.
        /// </summary>
        /// <param name="lockPermissionPolicy">The lock permission policy.</param>
        /// <returns></returns>
        Task InsertLockPermissionPolicyAsync(LockPermissionPolicy lockPermissionPolicy);

        /// <summary>
        /// Asynchronously finds the lock permission policies.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <param name="permissionId">The permission identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        Task<IEnumerable<LockPermissionPolicy>> FindLockPermissionPoliciesAsync(Guid lockId, Guid permissionId, Guid userId, params Guid[] roleIds);
    }
}
