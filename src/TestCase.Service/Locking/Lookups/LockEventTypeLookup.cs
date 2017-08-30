using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Locking.Lookups.Contract;
using TestCase.Service.Locking.Maps;

namespace TestCase.Service.Locking.Lookups
{
    /// <summary>
    /// Lock event type lookup.
    /// </summary>
    /// <seealso cref="TestCase.Service.Locking.Lookups.Contract.ILockEventTypeLookup" />
    public class LockEventTypeLookup : ILockEventTypeLookup
    {
        private readonly ILockEventRepository lockEventRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockEventTypeLookup"/> class.
        /// </summary>
        /// <param name="lockEventRepository">The lock event repository.</param>
        public LockEventTypeLookup(ILockEventRepository lockEventRepository)
        {
            this.lockEventRepository = lockEventRepository;
        }

        /// <summary>
        /// Asynchronously gets the access granted event type.
        /// </summary>
        /// <returns></returns>
        public Task<LockEventType> GetAccessGrantedEventTypeAsync() => GetAsync(LockEventTypeMap.AccessGranted);

        /// <summary>
        /// Asynchronously gets the access prohibited event type.
        /// </summary>
        /// <returns></returns>
        public Task<LockEventType> GetAccessProhibitedEventTypeAsync() => GetAsync(LockEventTypeMap.AccessProhibited);

        /// <summary>
        /// Asynchronously gets all lookup items.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LockEventType>> GetAllAsync() => this.lockEventRepository.GetLockEventTypesAsync();

        /// <summary>
        /// Asynchronously gets the lookup item.
        /// </summary>
        /// <param name="abrv">The abrv.</param>
        /// <returns></returns>
        public async Task<LockEventType> GetAsync(string abrv)
        {
            var eventTypes = await this.GetAllAsync();
            return eventTypes.FirstOrDefault(r => r.Abrv.Equals(abrv, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Asynchronously gets the locked event type.
        /// </summary>
        /// <returns></returns>
        public Task<LockEventType> GetLockedEventTypeAsync() => GetAsync(LockEventTypeMap.Locked);

        /// <summary>
        /// Asynchronously gets the unlocked event type.
        /// </summary>
        /// <returns></returns>
        public Task<LockEventType> GetUnlockedEventTypeAsync() => GetAsync(LockEventTypeMap.Unlocked);
    }
}
