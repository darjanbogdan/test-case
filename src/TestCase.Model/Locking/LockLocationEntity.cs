using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Model.Locking;

namespace TestCase.DataAccess.Entities.Locking
{
    /// <summary>
    /// Lock location model.
    /// </summary>
    public class LockLocation
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
        public IEnumerable<Lock> Locks { get; set; }
    }
}
