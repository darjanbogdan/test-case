using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Context;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;
using TestCase.Service.Security.Contracts;
using TestCase.Service.Security.Lookups.Contracts;

namespace TestCase.Service.Locking.Lock.GetLock
{
    /// <summary>
    /// Get lock query object permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Contracts.IObjectPermissionEvaluator{TestCase.Service.Locking.Lock.GetLock.GetLockQuery}" />
    public class GetLockQueryObjectPermissionEvaluator : IObjectPermissionEvaluator<GetLockQuery>
    {
        private readonly IExecutionContext executionContext;
        private readonly IPermissionLookup permissionLookup;
        private readonly IRoleLookup roleLookup;
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLockQueryObjectPermissionEvaluator" /> class.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        /// <param name="lockRepository">The lock repository.</param>
        public GetLockQueryObjectPermissionEvaluator(
            IExecutionContext executionContext,
            IPermissionLookup permissionLookup,
            IRoleLookup roleLookup,
            ILockRepository lockRepository)
        {
            this.executionContext = executionContext;
            this.permissionLookup = permissionLookup;
            this.roleLookup = roleLookup;
            this.lockRepository = lockRepository;
        }

        /// <summary>
        /// Asynchronously evaluates the object permissions for given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> EvaluateAsync(GetLockQuery model)
        {
            var existingLock = await this.lockRepository.GetLockAsync(model.LockId);
            if (existingLock == null)
            {
                throw new ArgumentException("Lock doesn't exist."); //404
            }

            var isOwner = this.executionContext.UserInfo.UserId.Equals(existingLock.UserId);
            if (!isOwner)
            {
                var readPermissionId = (await this.permissionLookup.GetReadPermissionAsync()).Id;

                var roles = new List<Guid>();
                foreach (var roleName in this.executionContext.UserInfo.Roles)
                {
                    var role = await this.roleLookup.GetAsync(roleName);
                    roles.Add(role.Id);
                }

                var policies = await this.lockRepository.FindLockPermissionPoliciesAsync(model.LockId, readPermissionId, this.executionContext.UserInfo.UserId, roles.ToArray());
                if (policies == null || !policies.Any())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
