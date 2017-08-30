using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;
using TestCase.Service.Infrastructure.Lookups.Contracts;

namespace TestCase.Service.Locking.Lookups.Contract
{
    /// <summary>
    /// Lock event type contract.
    /// </summary>
    /// <seealso cref="TestCase.Service.Infrastructure.Lookups.Contracts.ILookup{TestCase.Model.Locking.LockEventType}" />
    public interface ILockEventTypeLookup : ILookup<LockEventType>
    {
        /// <summary>
        /// Asynchronously gets the locked event type.
        /// </summary>
        /// <returns></returns>
        Task<LockEventType> GetLockedEventTypeAsync();

        /// <summary>
        /// Asynchronously gets the unlocked event type.
        /// </summary>
        /// <returns></returns>
        Task<LockEventType> GetUnlockedEventTypeAsync();

        /// <summary>
        /// Asynchronously gets the access granted event type.
        /// </summary>
        /// <returns></returns>
        Task<LockEventType> GetAccessGrantedEventTypeAsync();

        /// <summary>
        /// Asynchronously gets the access prohibited event type.
        /// </summary>
        /// <returns></returns>
        Task<LockEventType> GetAccessProhibitedEventTypeAsync();
    }
}
