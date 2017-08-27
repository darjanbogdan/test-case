using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;

namespace TestCase.Repository.Identity.Security
{
    /// <summary>
    /// Default user validator.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.UserValidator{TestCase.DataAccess.Entities.Identity.UserEntity, System.Guid}" />
    /// <seealso cref="Microsoft.AspNet.Identity.IIdentityValidator{TestCase.DataAccess.Entities.Identity.UserEntity}" />
    public class DefaultUserValidator : UserValidator<UserEntity, Guid>, IIdentityValidator<UserEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUserValidator"/> class.
        /// </summary>
        /// <param name="manager"></param>
        public DefaultUserValidator(UserManager<UserEntity, Guid> manager) 
            : base(manager)
        {
            AllowOnlyAlphanumericUserNames = true;
            RequireUniqueEmail = true;
        }
    }
}
