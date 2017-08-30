using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;

namespace TestCase.Repository.Locking.Contracts
{
    /// <summary>
    /// Lock event repository contract.
    /// </summary>
    public interface ILockEventRepository
    {
        /// <summary>
        /// Asynchronously gets all lock event types.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LockEventType>> GetLockEventTypesAsync();

        /// <summary>
        /// Asynchronously inserts the lock event.
        /// </summary>
        /// <param name="lockEvent">The lock event.</param>
        /// <returns></returns>
        Task InsertAsync(LockEvent lockEvent);

        /// <summary>
        /// Asynchronously finds the lock events.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<LockEvent>> FindAsync(Guid lockId); //TODO: Should support paging and sorting
    }
}
