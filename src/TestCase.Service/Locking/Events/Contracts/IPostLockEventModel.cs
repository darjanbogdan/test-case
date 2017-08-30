using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Service.Locking.Events.Contracts
{
    /// <summary>
    /// Post lock event model contract.
    /// </summary>
    public interface IPostLockEventModel
    {
        /// <summary>
        /// Gets the lock event type.
        /// </summary>
        string LockEventType { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        Guid LockId { get; }
    }
}
