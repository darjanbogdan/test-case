using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Model.Security
{
    /// <summary>
    /// Permission group.
    /// </summary>
    public class PermissionGroup
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abrv.
        /// </summary>
        public string Abrv { get; set; }
    }
}
