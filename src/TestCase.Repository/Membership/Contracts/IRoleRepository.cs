using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Membership;

namespace TestCase.Repository.Membership.Contracts
{
    /// <summary>
    /// Role repository contract.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Asynchronously finds the roles.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Role>> FindAsync();
    }
}
