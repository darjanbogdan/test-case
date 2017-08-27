using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Model.Membership;
using TestCase.Repository.Membership.Contracts;

namespace TestCase.Repository.Membership
{
    /// <summary>
    /// Account repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Identity.Contracts.IAccountRepository" />
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<UserEntity, Guid> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public AccountRepository(UserManager<UserEntity, Guid> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Asynchronously registers the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public async Task RegisterAsync(Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            var user = new UserEntity();
            user.Id = Guid.NewGuid(); //TODO: Replace with sequential GUID
            user.UserName = account.UserName;

            //TODO: Add claims to database

            var result = await this.userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(",", result.Errors));
            }
        }
    }
}
