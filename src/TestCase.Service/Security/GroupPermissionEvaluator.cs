using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Context;
using TestCase.Repository.Security.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;
using TestCase.Service.Security.Contracts;
using TestCase.Service.Security.Lookups.Contracts;

namespace TestCase.Service.Security
{
    /// <summary>
    /// Group permission evaluator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Auth.Contracts.IGroupPermissionEvaluator" />
    public class GroupPermissionEvaluator : IGroupPermissionEvaluator
    {
        private readonly IExecutionContext executionContext;
        private readonly IPermissionPolicyRepository permissionPolicyRepository;
        private readonly IRoleLookup roleLookup;
        private readonly IPermissionLookup permissionLookup;
        private readonly IPermissionGroupLookup permissionGroupLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupPermissionEvaluator"/> class.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        public GroupPermissionEvaluator(
            IExecutionContext executionContext, 
            IPermissionPolicyRepository permissionPolicyRepository,
            IRoleLookup roleLookup,
            IPermissionLookup permissionLookup,
            IPermissionGroupLookup permissionGroupLookup)
        {
            this.executionContext = executionContext;
            this.permissionPolicyRepository = permissionPolicyRepository;
            this.roleLookup = roleLookup;
            this.permissionLookup = permissionLookup;
            this.permissionGroupLookup = permissionGroupLookup;
        }

        /// <summary>
        /// Asynchronously evaluates the group permissions for given model.
        /// </summary>
        /// <param name="authorizeModel">The authorize model.</param>
        /// <returns></returns>
        public async Task EvaluateAsync(IAuthorizeModel authorizeModel)
        {
            var isOwner = this.executionContext.UserInfo.UserId.Equals(authorizeModel.OwnerId.GetValueOrDefault());
            if (!isOwner)
            {
                var permissionGroupId = (await this.permissionGroupLookup.GetAsync(authorizeModel.PermissionGroup)).Id;
                var permissionId = (await this.permissionLookup.GetAsync(authorizeModel.Permission)).Id;

                var userId = this.executionContext.UserInfo.UserId;
                var roleIds = new List<Guid>();
                foreach (var role in this.executionContext.UserInfo.Roles)
                {
                    var roleId = (await this.roleLookup.GetAsync(role)).Id;
                    roleIds.Add(roleId);
                }

                var policies = await this.permissionPolicyRepository.FindAsync(permissionGroupId, permissionId, userId, roleIds.ToArray());
                if (policies == null || !policies.Any())
                {
                    throw new UnauthorizedAccessException("Not Authorized");
                }
            }
        }
    }
}
