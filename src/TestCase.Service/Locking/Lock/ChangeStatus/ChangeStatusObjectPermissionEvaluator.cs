using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Context;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Security.Contracts;

namespace TestCase.Service.Locking.Lock.ChangeStatus
{
    /// <summary>
    /// Change status object permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Contracts.IObjectPermissionEvaluator{TestCase.Service.Locking.Lock.ChangeStatus.ChangeStatusCommand}" />
    public class ChangeStatusObjectPermissionEvaluator : IObjectPermissionEvaluator<ChangeStatusCommand>
    {
        private readonly ILockRepository lockRepository;
        private readonly IExecutionContext executionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStatusObjectPermissionEvaluator"/> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        public ChangeStatusObjectPermissionEvaluator(ILockRepository lockRepository, IExecutionContext executionContext)
        {
            this.lockRepository = lockRepository;
            this.executionContext = executionContext;
        }

        /// <summary>
        /// Asynchronously evaluates the object permissions for given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> EvaluateAsync(ChangeStatusCommand model)
        {
            var existingLock = await this.lockRepository.GetLockAsync(model.LockId);
            if (existingLock == null)
            {
                throw new ArgumentException("Lock doesn't exist."); //TODO: 404 should be thrown, custom exception implement
            }

            var isOwner = this.executionContext.UserInfo.UserId.Equals(existingLock.UserId);
            if (!isOwner)
            {
                //TODO: Implement Object permission fetch....
            }
            return isOwner;
        }
    }
}
