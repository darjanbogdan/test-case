using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;
using TestCase.DataAccess.Entities.Identity;

namespace TestCase.DataAccess.Entities.Locking
{
    /// <summary>
    /// Lock entity.
    /// </summary>
    /// <seealso cref="TestCase.DataAccess.Entities.Contracts.IEntity" />
    public class LockEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public UserEntity User { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LockEntity"/> is locked.
        /// </summary>
        public bool Locked { get; set; } //Note: Simplified -> Status table would be more appropriate to support more than two "lock states"

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public LockLocationEntity Location { get; set; }
    }
}
