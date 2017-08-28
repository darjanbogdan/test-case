using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Membership;

namespace TestCase.Repository.Membership.Contracts
{
    /// <summary>
    /// Account repository contract.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Asynchronously registers the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        Task RegisterAsync(Account account);

        /// <summary>
        /// Asynchronously gets the account.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<Account> GetAsync(string userName, string password);

        /// <summary>
        /// Asynchronously inserts the user roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        Task InsertUserRolesAsync(Guid userId, params Role[] roles);
    }
}
