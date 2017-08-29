using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Model.Membership;
using TestCase.Repository.Identity.Claims.Contracts;

namespace TestCase.Repository.Identity.Claims
{
    /// <summary>
    /// Claims identity provider.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Identity.Providers.Contracts.IClaimsIdentityProvider" />
    public class ClaimsIdentityProvider : IClaimsIdentityProvider
    {
        private readonly UserManager<UserEntity, Guid> userManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsIdentityProvider" /> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="mapper">The mapper.</param>
        public ClaimsIdentityProvider(UserManager<UserEntity, Guid> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously gets the claims identity.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GetAsync(User user)
        {
            const string authenticationType = "JWT";
            var entity = this.mapper.Map<User, UserEntity>(user);
            return await this.userManager.CreateIdentityAsync(entity, authenticationType);
        }
    }
}
