using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;

namespace TestCase.DataAccess.Entities.Locking
{
    /// <summary>
    /// Lock event type entity.
    /// </summary>
    /// <seealso cref="TestCase.DataAccess.Entities.Contracts.IEntity" />
    public class LockEventTypeEntity : IEntity
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
        /// Gets or sets the abrv.
        /// </summary>
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
