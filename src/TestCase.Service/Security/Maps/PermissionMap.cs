using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Service.Security.Maps
{
    /// <summary>
    /// Permission map.
    /// </summary>
    public class PermissionMap
    {
        /// <summary>
        /// The create permission.
        /// </summary>
        public const string Create = "create";

        /// <summary>
        /// The read permission
        /// </summary>
        public const string Read = "read";

        /// <summary>
        /// The update permission
        /// </summary>
        public const string Update = "update";

        /// <summary>
        /// The delete permission.
        /// </summary>
        public const string Delete = "delete";

        /// <summary>
        /// The full permission.
        /// </summary>
        public const string Full = "full";
    }
}
