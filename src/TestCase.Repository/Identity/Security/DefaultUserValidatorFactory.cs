using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Repository.Identity.Security.Contracts;

namespace TestCase.Repository.Identity.Security
{
    /// <summary>
    /// User validator factory.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Identity.Security.IIdentityUserValidatorFactory" />
    public class DefaultUserValidatorFactory : IIdentityUserValidatorFactory
    {
        /// <summary>
        /// Creates the specified user manager.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <returns></returns>
        public IIdentityValidator<UserEntity> Create(UserManager<UserEntity, Guid> userManager)
        {
            return new DefaultUserValidator(userManager);
        }
    }
}
