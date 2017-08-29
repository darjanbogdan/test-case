using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Membership;

namespace TestCase.Repository.Membership.Contracts
{
    /// <summary>
    /// User repository contract.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Asynchronously registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task RegisterAsync(User user, string password);

        /// <summary>
        /// Asynchronously gets the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<User> GetAsync(string userName, string password);

        /// <summary>
        /// Asynchronously inserts the user roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        Task InsertUserRolesAsync(Guid userId, params Role[] roles);
    }
}
