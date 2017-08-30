using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Context;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;
using TestCase.Service.Security.Contracts;
using TestCase.Service.Security.Lookups.Contracts;

namespace TestCase.Service.Locking.Lock.ChangeLockStatus
{
    /// <summary>
    /// Change lock status object permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Contracts.IObjectPermissionEvaluator{TestCase.Service.Locking.Lock.ChangeStatus.ChangeStatusCommand}" />
    public class ChangeLockStatusObjectPermissionEvaluator : IObjectPermissionEvaluator<ChangeLockStatusCommand>
    {
        private readonly ILockRepository lockRepository;
        private readonly IPermissionLookup permissionLookup;
        private readonly IRoleLookup roleLookup;
        private readonly IExecutionContext executionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeLockStatusObjectPermissionEvaluator"/> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        public ChangeLockStatusObjectPermissionEvaluator(
            ILockRepository lockRepository, 
            IPermissionLookup permissionLookup,
            IRoleLookup roleLookup,
            IExecutionContext executionContext)
        {
            this.lockRepository = lockRepository;
            this.permissionLookup = permissionLookup;
            this.roleLookup = roleLookup;
            this.executionContext = executionContext;
        }

        /// <summary>
        /// Asynchronously evaluates the object permissions for given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Lock doesn't exist.</exception>
        public async Task<bool> EvaluateAsync(ChangeLockStatusCommand model)
        {
            var existingLock = await this.lockRepository.GetLockAsync(model.LockId);
            if (existingLock == null)
            {
                throw new ArgumentException("Lock doesn't exist."); //TODO: 404 should be thrown, custom exception implement
            }

            var isOwner = this.executionContext.UserInfo.UserId.Equals(existingLock.UserId);
            if (!isOwner)
            {
                var updatePermissionId = (await this.permissionLookup.GetUpdatePermissionAsync()).Id;

                var roles = new List<Guid>();
                foreach (var roleName in this.executionContext.UserInfo.Roles)
                {
                    var role = await this.roleLookup.GetAsync(roleName);
                    roles.Add(role.Id);
                }

                var policies = await this.lockRepository.FindLockPermissionPoliciesAsync(model.LockId, updatePermissionId, this.executionContext.UserInfo.UserId, roles.ToArray());
                if (policies == null || !policies.Any())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
