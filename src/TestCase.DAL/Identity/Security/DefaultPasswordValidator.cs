using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DAL.Identity.Security
{
    /// <summary>
    /// Default password validator.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.PasswordValidator" />
    public class DefaultPasswordValidator : PasswordValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultPasswordValidator"/> class.
        /// </summary>
        public DefaultPasswordValidator()
        {
            RequiredLength = 6;
        }
    }
}
