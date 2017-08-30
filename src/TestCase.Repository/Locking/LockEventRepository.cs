using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Locking;
using TestCase.Repository.Locking.Contracts;
using TestCase.Model.Locking;

namespace TestCase.Repository.Locking
{
    /// <summary>
    /// Lock event repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Locking.Contracts.ILockEventRepository" />
    public class LockEventRepository : ILockEventRepository
    {
        private readonly IGenericRepository<LockEventEntity> genericLockEventRepository;
        private readonly IGenericRepository<LockEventTypeEntity> genericLockEventTypeRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockEventRepository" /> class.
        /// </summary>
        /// <param name="genericLockEventRepository">The generic repository.</param>
        /// <param name="genericLockEventTypeRepository">The generic lock event type repository.</param>
        /// <param name="mapper">The mapper.</param>
        public LockEventRepository(
            IGenericRepository<LockEventEntity> genericLockEventRepository,
            IGenericRepository<LockEventTypeEntity> genericLockEventTypeRepository,
            IMapper mapper)
        {
            this.genericLockEventRepository = genericLockEventRepository;
            this.genericLockEventTypeRepository = genericLockEventTypeRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously finds the lock events.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<LockEvent>> FindAsync(Guid lockId)
        {
            var query = await this.genericLockEventRepository.FindAsync();
            var entities = query.Where(p => p.LockId == lockId);
            return this.mapper.Map<IEnumerable<LockEvent>>(entities);
        }

        /// <summary>
        /// Asynchronously gets all lock event types.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LockEventType>> GetLockEventTypesAsync()
        {
            var entities = await this.genericLockEventTypeRepository.GetAllAsync();
            return this.mapper.Map<IEnumerable<LockEventType>>(entities);
        }

        /// <summary>
        /// Asynchronously inserts the lock event.
        /// </summary>
        /// <param name="lockEvent">The lock event.</param>
        /// <returns></returns>
        public Task InsertAsync(LockEvent lockEvent)
        {
            if (lockEvent == null) throw new ArgumentNullException(nameof(lockEvent));

            var entity = this.mapper.Map<LockEventEntity>(lockEvent);
            return this.genericLockEventRepository.InsertAsync(entity);
        }
    }
}
