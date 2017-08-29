using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;

namespace TestCase.DataAccess.Entities.Locking
{
    /// <summary>
    /// Lock event entity.
    /// </summary>
    /// <seealso cref="TestCase.DataAccess.Entities.Contracts.IEntity" />
    public class LockEventEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the lock identifier.
        /// </summary>
        public Guid LockId { get; set; }

        /// <summary>
        /// Gets or sets the lock.
        /// </summary>
        public LockEntity Lock { get; set; }

        /// <summary>
        /// Gets or sets the lock event type identifier.
        /// </summary>
        public Guid LockEventTypeId { get; set; }

        /// <summary>
        /// Gets the type of the lock event.
        /// </summary>
        public LockEventTypeEntity LockEventType { get; set; }
    }
}
