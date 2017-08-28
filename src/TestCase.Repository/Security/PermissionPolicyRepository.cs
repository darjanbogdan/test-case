using AutoMapper;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Security;
using TestCase.Model.Security;
using TestCase.Repository.Security.Contracts;

namespace TestCase.Repository.Security
{
    /// <summary>
    /// Permission policy repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Security.Contracts.IPermissionPolicyRepository" />
    public class PermissionPolicyRepository : IPermissionPolicyRepository
    {
        private readonly IGenericRepository<PermissionPolicyEntity> genericRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionPolicyRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public PermissionPolicyRepository(IGenericRepository<PermissionPolicyEntity> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously finds the permission policies.
        /// </summary>
        /// <param name="permissionGroupId">The permission group identifier.</param>
        /// <param name="permissionId">The permission identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public async Task<IEnumerable<PermissionPolicy>> FindAsync(Guid permissionGroupId, Guid permissionId, Guid userId, params Guid[] roleIds)
        {
            var query = await this.genericRepository.FindAsync();

            var predicate = PredicateBuilder.New<PermissionPolicyEntity>(p => p.PermissionGroupId == permissionGroupId);
            predicate.And(p => p.PermissionId == permissionId);
            
            var innerPredicate = PredicateBuilder.New<PermissionPolicyEntity>(p => p.UserId.HasValue && p.UserId.Value.Equals(userId));
            innerPredicate.Or(p => p.RoleId.HasValue && roleIds.Contains(p.RoleId.Value));

            predicate.And(innerPredicate);

            var entites = await query.Where(predicate).ToListAsync();
            return this.mapper.Map<List<PermissionPolicy>>(entites);
        }
    }
}
