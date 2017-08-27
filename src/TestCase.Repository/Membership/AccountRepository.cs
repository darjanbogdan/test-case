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

            var user = new UserEntity
            {
                Id = Guid.NewGuid(), //TODO: Replace with sequential GUID
                UserName = account.UserName,
                Email = account.Email
            };

            //TODO: Add claims to database

            var result = await this.userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(",", result.Errors));
            }
        }

        /// <summary>
        /// Asynchronously gets the account.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">account</exception>
        public async Task<Account> GetAsync(string userName, string password)
        {
            var user = await this.userManager.FindAsync(userName, password);
            return new Account
            {
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                Password = user.PasswordHash,
                UserId = user.Id,
                UserName = user.UserName
            };
        }
    }
}
