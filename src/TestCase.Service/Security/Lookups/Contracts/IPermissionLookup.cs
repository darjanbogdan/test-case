using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;
using TestCase.Service.Infrastructure.Lookups.Contracts;

namespace TestCase.Service.Security.Lookups.Contracts
{
    /// <summary>
    /// Permission lookup interface.
    /// </summary>
    /// <seealso cref="TestCase.Service.Infrastructure.Lookups.Contracts.ILookup{TestCase.Model.Security.Permission}" />
    public interface IPermissionLookup : ILookup<Permission>
    {
        /// <summary>
        /// Asynchronously gets the create permission.
        /// </summary>
        /// <returns></returns>
        Task<Permission> GetCreatePermissionAsync();

        /// <summary>
        /// Asynchronously gets the read permission.
        /// </summary>
        /// <returns></returns>
        Task<Permission> GetReadPermissionAsync();

        /// <summary>
        /// Asynchronously gets the update permission.
        /// </summary>
        /// <returns></returns>
        Task<Permission> GetUpdatePermissionAsync();

        /// <summary>
        /// Asynchronously gets the delete permission.
        /// </summary>
        /// <returns></returns>
        Task<Permission> GetDeletePermissionAsync();

        /// <summary>
        /// Asynchronously gets the update permission.
        /// </summary>
        /// <returns></returns>
        Task<Permission> GetFullPermissionAsync();
    }
}
