using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;

namespace TestCase.Service.Locking.Lock.GetLock
{
    /// <summary>
    /// Get lock result.
    /// </summary>
    public class GetLockResult
    {
        /// <summary>
        /// Gets or sets the lock.
        /// </summary>
        public Model.Locking.Lock Lock { get; set; }
    }
}
