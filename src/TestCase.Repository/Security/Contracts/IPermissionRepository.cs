using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;

namespace TestCase.Repository.Security.Contracts
{
    /// <summary>
    /// Permission repository contract.
    /// </summary>
    public interface IPermissionRepository
    {
        /// <summary>
        /// Asynchronously gets all permissions.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Permission>> GetAllAsync();
    }
}
