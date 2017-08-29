using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Membership;
using TestCase.Repository.Membership.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;
using TestCase.Service.Membership.Maps;

namespace TestCase.Service.Membership.Lookups
{
    /// <summary>
    /// Role lookup.
    /// </summary>
    /// <seealso cref="TestCase.Service.Membership.Lookups.Contracts.IRoleLookup" />
    public class RoleLookup : IRoleLookup
    {
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleLookup"/> class.
        /// </summary>
        /// <param name="roleRepository">The role repository.</param>
        public RoleLookup(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// Asynchronously gets all lookup items.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Role>> GetAllAsync() => this.roleRepository.FindAsync();
        

        /// <summary>
        /// Asynchronously gets the lookup item.
        /// </summary>
        /// <param name="abrv">The abrv.</param>
        /// <returns></returns>
        public async Task<Role> GetAsync(string abrv)
        {
            var roles = await this.GetAllAsync();
            return roles.FirstOrDefault(r => r.Name.Equals(abrv, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Asynchronously gets the admin role.
        /// </summary>
        /// <returns></returns>
        public Task<Role> GetAdminRoleAsync() => GetAsync(RoleMap.Admin);

        /// <summary>
        /// Asynchronously gets the user role.
        /// </summary>
        /// <returns></returns>
        public Task<Role> GetUserRoleAsync() => GetAsync(RoleMap.User);
    }
}
