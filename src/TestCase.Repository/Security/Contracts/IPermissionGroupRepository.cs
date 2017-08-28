using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Security;

namespace TestCase.Repository.Security.Contracts
{
    /// <summary>
    /// Permission group repository contract.
    /// </summary>
    public interface IPermissionGroupRepository
    {
        /// <summary>
        /// Asynchronously gets all permission groups.
        /// </summary>
        /// <returns></returns>
        Task<IList<PermissionGroup>> GetAllAsync();
    }
}
