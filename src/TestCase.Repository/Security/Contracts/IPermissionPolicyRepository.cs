using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;

namespace TestCase.Repository.Security.Contracts
{
    /// <summary>
    /// Permission policy repository contract.
    /// </summary>
    public interface IPermissionPolicyRepository
    {
        /// <summary>
        /// Asynchronously finds the permission policies.
        /// </summary>
        /// <param name="permissionGroupId">The permission group identifier.</param>
        /// <param name="permissionId">The permission identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        Task<IEnumerable<PermissionPolicy>> FindAsync(Guid permissionGroupId, Guid permissionId, Guid userId, params Guid[] roleIds);
    }
}
