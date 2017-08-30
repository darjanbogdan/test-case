using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Service.Locking.Maps
{
    /// <summary>
    /// Lock event type map.
    /// </summary>
    public class LockEventTypeMap
    {
        /// <summary>
        /// The access granted
        /// </summary>
        public const string AccessGranted = "access-granted";

        /// <summary>
        /// The access prohibited
        /// </summary>
        public const string AccessProhibited = "access-prohibited";

        /// <summary>
        /// The locked
        /// </summary>
        public const string Locked = "locked";

        /// <summary>
        /// The unlocked
        /// </summary>
        public const string Unlocked = "unlocked";
    }
}
