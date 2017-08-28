using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Membership;
using TestCase.Service.Infrastructure.Lookups.Contracts;

namespace TestCase.Service.Membership.Lookups.Contracts
{
    /// <summary>
    /// Role lookup interface.
    /// </summary>
    public interface IRoleLookup : ILookup<Role>
    {
        /// <summary>
        /// Asynchronously gets the user role.
        /// </summary>
        /// <returns></returns>
        Task<Role> GetUserRoleAsync();

        /// <summary>
        /// Asynchronously gets the admin role.
        /// </summary>
        /// <returns></returns>
        Task<Role> GetAdminRoleAsync();
    }
}
