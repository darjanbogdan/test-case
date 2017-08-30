using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Context;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Security.Contracts;

namespace TestCase.Service.Locking.Lock.DeleteLockPermission
{
    /// <summary>
    /// Delete lock permission object permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Contracts.IObjectPermissionEvaluator{TestCase.Service.Locking.Lock.DeleteLockPermission.DeleteLockPermissionCommand}" />
    public class DeleteLockPermissionObjectPermissionEvaluator : IObjectPermissionEvaluator<DeleteLockPermissionCommand>
    {
        private readonly ILockRepository lockRepository;
        private readonly IExecutionContext executionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLockPermissionObjectPermissionEvaluator"/> class.
        /// </summary>
        public DeleteLockPermissionObjectPermissionEvaluator(
            ILockRepository lockRepository,
            IExecutionContext executionContext)
        {
            this.lockRepository = lockRepository;
            this.executionContext = executionContext;
        }

        /// <summary>
        /// Asynchronously evaluates the object permissions for given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> EvaluateAsync(DeleteLockPermissionCommand model)
        {
            var existingLock = await this.lockRepository.GetLockAsync(model.LockId);
            if (existingLock == null)
            {
                throw new ArgumentException("Lock doesn't exist."); //404
            }

            var isOwner = this.executionContext.UserInfo.UserId.Equals(existingLock.UserId);
            if (!isOwner)
            {
                //NOTE: Only owners can remove lock permission policy.
                //NOTE: Could be extended with admins as well
                throw new UnauthorizedAccessException("Not Authorized.");
            }
            return true;
        }
    }
}
