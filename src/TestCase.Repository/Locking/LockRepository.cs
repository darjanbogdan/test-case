using AutoMapper;
using System;
using System.Collections.Generic;
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
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockRepository" /> class.
        /// </summary>
        /// <param name="genericLockRepository">The generic lock repository.</param>
        /// <param name="genericLockLocationRepository">The generic lock location repository.</param>
        /// <param name="mapper">The mapper.</param>
        public LockRepository(
            IGenericRepository<LockEntity> genericLockRepository,
            IGenericRepository<LockLocationEntity> genericLockLocationRepository,
            IMapper mapper)
        {
            
            this.genericLockRepository = genericLockRepository;
            this.genericLockLocationRepository = genericLockLocationRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously gets the lock.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        public async Task<Lock> GetLockAsync(Guid lockId)
        {
            var @lock = await this.genericLockRepository.GetAsync(lockId);
            return this.mapper.Map<Lock>(@lock);
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
    }
}
