using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;

namespace TestCase.Repository.Identity.Security.Contracts
{
    /// <summary>
    /// User validator factory
    /// </summary>
    public interface IIdentityUserValidatorFactory
    {
        /// <summary>
        /// Creates the specified user manager.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <returns></returns>
        IIdentityValidator<UserEntity> Create(UserManager<UserEntity, Guid> userManager);
    }
}
