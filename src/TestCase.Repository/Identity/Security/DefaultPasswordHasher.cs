using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Repository.Identity.Security
{
    /// <summary>
    /// Default password hasher.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IPasswordHasher" />
    public class DefaultPasswordHasher : PasswordHasher
    {
        /// <summary>
        /// Hash a password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public override string HashPassword(string password)
        {
#if DEBUG
            return password;
#else
            return base.HashPassword(password);
#endif
        }

        /// <summary>
        /// Verify that a password matches the hashed password
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <param name="providedPassword"></param>
        /// <returns></returns>
        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
#if DEBUG
            if (hashedPassword.Equals(providedPassword))
            { 
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
#else
            return base.VerifyHashedPassword(hashedPassword, providedPassword);
#endif
        }
    }
}
