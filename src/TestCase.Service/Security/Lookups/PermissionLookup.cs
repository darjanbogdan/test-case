using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;
using TestCase.Repository.Security.Contracts;
using TestCase.Service.Security.Lookups.Contracts;
using TestCase.Service.Security.Maps;

namespace TestCase.Service.Security.Lookups
{
    /// <summary>
    /// Permission lookup.
    /// </summary>
    /// <seealso cref="TestCase.Service.Security.Lookups.Contracts.IPermissionLookup" />
    public class PermissionLookup : IPermissionLookup
    {
        private readonly IPermissionRepository permissionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionLookup"/> class.
        /// </summary>
        /// <param name="permissionRepository">The permission repository.</param>
        public PermissionLookup(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        /// <summary>
        /// Asynchronously gets all permissions.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Permission>> GetAllAsync() => this.permissionRepository.GetAllAsync();

        /// <summary>
        /// Asynchronously gets the permission.
        /// </summary>
        /// <param name="abrv">The abrv.</param>
        /// <returns></returns>
        public async Task<Permission> GetAsync(string abrv)
        {
            var permissions = await this.GetAllAsync();
            return permissions.FirstOrDefault(p => p.Abrv.Equals(abrv, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Asynchronously gets the create permission.
        /// </summary>
        /// <returns></returns>
        public Task<Permission> GetCreatePermissionAsync()
        {
            return GetAsync(PermissionMap.Create);
        }

        /// <summary>
        /// Asynchronously gets the delete permission.
        /// </summary>
        /// <returns></returns>
        public Task<Permission> GetDeletePermissionAsync()
        {
            return GetAsync(PermissionMap.Delete);
        }

        /// <summary>
        /// Asynchronously gets the update permission.
        /// </summary>
        /// <returns></returns>
        public Task<Permission> GetFullPermissionAsync()
        {
            return GetAsync(PermissionMap.Full);
        }

        /// <summary>
        /// Asynchronously gets the read permission.
        /// </summary>
        /// <returns></returns>
        public Task<Permission> GetReadPermissionAsync()
        {
            return GetAsync(PermissionMap.Read);
        }

        /// <summary>
        /// Asynchronously gets the update permission.
        /// </summary>
        /// <returns></returns>
        public Task<Permission> GetUpdatePermissionAsync()
        {
            return GetAsync(PermissionMap.Update);
        }
    }
}
