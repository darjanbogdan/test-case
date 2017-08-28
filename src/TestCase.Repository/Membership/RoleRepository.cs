using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Model.Membership;
using TestCase.Repository.Membership.Contracts;

namespace TestCase.Repository.Membership
{
    /// <summary>
    /// Role repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Membership.Contracts.IRoleRepository" />
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<RoleEntity, Guid> roleManager;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository" /> class.
        /// </summary>
        /// <param name="roleManager">The role manager.</param>
        /// <param name="mapper">The mapper.</param>
        public RoleRepository(RoleManager<RoleEntity, Guid> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously finds the roles.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Role>> FindAsync()
        {
            var roles = this.roleManager.Roles.ToList();
            return Task.FromResult(this.mapper.Map<IEnumerable<Role>>(roles));
        }
    }
}
