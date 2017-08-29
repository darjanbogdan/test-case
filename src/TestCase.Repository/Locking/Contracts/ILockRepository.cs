using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;

namespace TestCase.Repository.Locking.Contracts
{
    /// <summary>
    /// Lock repository contract.
    /// </summary>
    public interface ILockRepository
    {
        /// <summary>
        /// Asynchronously inserts the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        Task InsertLockAsync(Lock @lock);

        /// <summary>
        /// Asynchronously gets the lock.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        Task<Lock> GetLockAsync(Guid lockId);

        /// <summary>
        /// Asynchronously updates the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        Task UpdateLockAsync(Lock @lock);

        /// <summary>
        /// Asynchronously inserts the lock location.
        /// </summary>
        /// <param name="lockLocation">The lock location.</param>
        /// <returns></returns>
        Task InsertLockLocationAsync(LockLocation lockLocation);

    }
}
