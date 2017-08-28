using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Context;
using TestCase.Service.Auth.Contracts;

namespace TestCase.Service.Auth
{
    /// <summary>
    /// Group permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Auth.Contracts.IGroupPermissionEvaluator" />
    public class GroupPermissionEvaluator : IGroupPermissionEvaluator
    {
        private readonly IExecutionContext executionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupPermissionEvaluator"/> class.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        public GroupPermissionEvaluator(IExecutionContext executionContext)
        {
            this.executionContext = executionContext;
        }

        /// <summary>
        /// Asynchronously evaluates the group permissions for give model.
        /// </summary>
        /// <param name="authorizeModel">The authorize model.</param>
        /// <returns></returns>
        public async Task EvaluateAsync(IAuthorizeModel authorizeModel)
        {
            var isOwner = this.executionContext.UserInfo.UserId.Equals(authorizeModel.OwnerId.GetValueOrDefault());
            if (!isOwner)
            {

            }
        }
    }
}
