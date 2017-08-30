using AutoMapper;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Locking;
using TestCase.Model.Locking;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Repository.Locking
{
    /// <summary>
    /// Lock repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Locking.Contracts.ILockRepository" />
    public class LockRepository : ILockRepository
    {
        private readonly IGenericRepository<LockEntity> genericLockRepository;
        private readonly IGenericRepository<LockLocationEntity> genericLockLocationRepository;
        private readonly IGenericRepository<LockPermissionPolicyEntity> genericLockPermissionPolicyRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockRepository" /> class.
        /// </summary>
        /// <param name="genericLockRepository">The generic lock repository.</param>
        /// <param name="genericLockLocationRepository">The generic lock location repository.</param>
        /// <param name="genericLockPermissionPolicyRepository">The generic lock permission policy repository.</param>
        /// <param name="mapper">The mapper.</param>
        public LockRepository(
            IGenericRepository<LockEntity> genericLockRepository,
            IGenericRepository<LockLocationEntity> genericLockLocationRepository,
            IGenericRepository<LockPermissionPolicyEntity> genericLockPermissionPolicyRepository,
            IMapper mapper)
        {
            
            this.genericLockRepository = genericLockRepository;
            this.genericLockLocationRepository = genericLockLocationRepository;
            this.genericLockPermissionPolicyRepository = genericLockPermissionPolicyRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously gets the lock.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        public async Task<Lock> GetLockAsync(Guid lockId)
        {
            var query = await this.genericLockRepository.FindAsync();

            query = query
                .Include(p => p.Location)
                .Include(p => p.Events)
                .Include(p => p.Events.Select(e => e.LockEventType));

            query = query.Where(p => p.Id == lockId);

            var entity = await query.SingleOrDefaultAsync();
            return this.mapper.Map<Lock>(entity);
        }

        /// <summary>
        /// Asynchronously inserts the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        public Task InsertLockAsync(Lock @lock)
        {
            if (@lock == null) throw new ArgumentNullException(nameof(@lock));

            var entity = this.mapper.Map<LockEntity>(@lock);
            return this.genericLockRepository.InsertAsync(entity);
        }

        /// <summary>
        /// Asynchronously inserts the lock location.
        /// </summary>
        /// <param name="lockLocation">The lock location.</param>
        /// <returns></returns>
        public Task InsertLockLocationAsync(LockLocation lockLocation)
        {
            if (lockLocation == null) throw new ArgumentNullException(nameof(lockLocation));

            var entity = this.mapper.Map<LockLocationEntity>(lockLocation);
            return this.genericLockLocationRepository.InsertAsync(entity);
        }

        /// <summary>
        /// Asynchronously inserts the lock permission policy.
        /// </summary>
        /// <param name="lockPermissionPolicy">The lock permission policy.</param>
        /// <returns></returns>
        public Task InsertLockPermissionPolicyAsync(LockPermissionPolicy lockPermissionPolicy)
        {
            if (lockPermissionPolicy == null) throw new ArgumentNullException(nameof(lockPermissionPolicy));

            var entity = this.mapper.Map<LockPermissionPolicyEntity>(lockPermissionPolicy);
            try
            {
                return this.genericLockPermissionPolicyRepository.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Asynchronously finds the lock permission policies.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <param name="permissionId">The permission identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public async Task<IEnumerable<LockPermissionPolicy>> FindLockPermissionPoliciesAsync(Guid lockId, Guid permissionId, Guid userId, params Guid[] roleIds)
        {
            var query = await this.genericLockPermissionPolicyRepository.FindAsync();

            var predicate = PredicateBuilder.New<LockPermissionPolicyEntity>(pp => pp.LockId == lockId && pp.PermissionId == permissionId);

            var innerPredicate = PredicateBuilder.New<LockPermissionPolicyEntity>(pp => pp.UserId.HasValue && pp.UserId.Value.Equals(userId));
            innerPredicate.Or(pp => pp.RoleId.HasValue && roleIds.Contains(pp.RoleId.Value));

            predicate.And(innerPredicate);

            var policies = await query.Where(predicate).ToListAsync();
            return this.mapper.Map<IEnumerable<LockPermissionPolicy>>(policies);
        }

        /// <summary>
        /// Asynchronously updates the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        public Task UpdateLockAsync(Lock @lock)
        {
            if (@lock == null) throw new ArgumentNullException(nameof(@lock));

            var entity = this.mapper.Map<LockEntity>(@lock);
            return this.genericLockRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// Asynchronously deletes the lock permission.
        /// </summary>
        /// <param name="lockPermissionId">The lock permission identifier.</param>
        /// <returns></returns>
        public Task DeleteLockPermissionAsync(Guid lockPermissionId)
        {
            return this.genericLockPermissionPolicyRepository.DeleteAsync(lockPermissionId);
        }

        /// <summary>
        /// Asynchronously gets the lock permission.
        /// </summary>
        /// <param name="lockPermissionId">The lock permission identifier.</param>
        /// <returns></returns>
        public async Task<LockPermissionPolicy> GetLockPermissionAsync(Guid lockPermissionId)
        {
            var entity = await this.genericLockPermissionPolicyRepository.GetAsync(lockPermissionId);
            return this.mapper.Map<LockPermissionPolicyEntity, LockPermissionPolicy>(entity);
        }
    }
}
