using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;
using TestCase.Repository.Security.Contracts;
using TestCase.Service.Security.Lookups.Contracts;

namespace TestCase.Service.Security.Lookups
{
    /// <summary>
    /// Permission group lookup.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Lookups.Contracts.IPermissionGroupLookup" />
    public class PermissionGroupLookup : IPermissionGroupLookup
    {
        private readonly IPermissionGroupRepository permissionGroupRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionGroupLookup"/> class.
        /// </summary>
        /// <param name="permissionGroupRepository">The permission group repository.</param>
        public PermissionGroupLookup(IPermissionGroupRepository permissionGroupRepository)
        {
            this.permissionGroupRepository = permissionGroupRepository;
        }

        /// <summary>
        /// Asynchronously gets all permission groups.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<PermissionGroup>> GetAllAsync() => this.permissionGroupRepository.GetAllAsync();

        /// <summary>
        /// Asynchronously gets the permission group.
        /// </summary>
        /// <param name="abrv">The abrv.</param>
        /// <returns></returns>
        public async Task<PermissionGroup> GetAsync(string abrv)
        {
            var permissionGroups = await this.GetAllAsync();
            return permissionGroups.FirstOrDefault(r => r.Abrv.Equals(abrv, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
