using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;

namespace TestCase.DataAccess.Entities.Locking
{
    /// <summary>
    /// Lock location entity.
    /// </summary>
    public class LockLocationEntity : IEntity
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
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; } //Note: Simplified -> Should be normalized

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; } //Note: Simplified -> Should be normalized

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; } //Note: Simplified -> Should be normalized

        /// <summary>
        /// Gets or sets the locks.
        /// </summary>
        public ICollection<LockEntity> Locks { get; set; }
    }
}
