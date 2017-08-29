using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Model.Membership
{
    /// <summary>
    /// User model.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether email is confirmed.
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }
}
