using AutoMapper;
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
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository" /> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountRepository(UserManager<UserEntity, Guid> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously registers the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">account</exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task RegisterAsync(Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            var user = this.mapper.Map<Account, UserEntity>(account);
            
            //TODO: Add claims to database

            var result = await this.userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException(String.Join(",", result.Errors));
            }
        }

        /// <summary>
        /// Asynchronously inserts the user roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">roles</exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task InsertUserRolesAsync(Guid userId, params Role[] roles)
        {
            if (roles == null) throw new ArgumentNullException(nameof(roles));

            var result = await this.userManager.AddToRolesAsync(userId, roles.Select(r => r.Name).ToArray());
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
        public async Task<Account> GetAsync(string userName, string password)
        {
            var user = await this.userManager.FindAsync(userName, password);
            var account = this.mapper.Map<UserEntity, Account>(user);
            account.UserId = user.Id;
            return account;
        }
    }
}
