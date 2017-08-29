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
    /// User repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Membership.Contracts.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity, Guid> userManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="mapper">The mapper.</param>
        public UserRepository(UserManager<UserEntity, Guid> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">user</exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task RegisterAsync(User user, string password)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (String.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            var entity = this.mapper.Map<User, UserEntity>(user);

            //TODO: Add claims to database

            var result = await this.userManager.CreateAsync(entity, password);
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
        /// Asynchronously gets the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<User> GetAsync(string userName, string password)
        {
            var entity = await this.userManager.FindAsync(userName, password);
            return this.mapper.Map<UserEntity, User>(entity);
        }
    }
}
