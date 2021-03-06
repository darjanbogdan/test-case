﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Context;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Infrastructure.Exceptions;
using TestCase.Service.Security.Contracts;

namespace TestCase.Service.Locking.Lock.CreateLockPermission
{
    /// <summary>
    /// Create lock permission object permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Contracts.IObjectPermissionEvaluator{TestCase.Service.Locking.Lock.CreateLockPermission.CreateLockPermissionCommand}" />
    public class CreateLockPermissionObjectPermissionEvaluator : IObjectPermissionEvaluator<CreateLockPermissionCommand>
    {
        private readonly ILockRepository lockRepository;
        private readonly IExecutionContext executionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLockPermissionObjectPermissionEvaluator" /> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        /// <param name="executionContext">The execution context.</param>
        public CreateLockPermissionObjectPermissionEvaluator(
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
        public async Task<bool> EvaluateAsync(CreateLockPermissionCommand model)
        {
            var existingLock = await this.lockRepository.GetLockAsync(model.LockId);
            if (existingLock == null)
            {
                throw new NotFoundException("Lock");
            }

            var isOwner = this.executionContext.UserInfo.UserId.Equals(existingLock.UserId);
            if (!isOwner)
            {
                //NOTE: Only owners can add new lock permission policy.
                //NOTE: Could be extended with admins as well
                throw new UnauthorizedAccessException("Not Authorized");
            }
            return true;
        }
    }
}
