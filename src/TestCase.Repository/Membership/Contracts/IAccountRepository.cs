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
    }
}
