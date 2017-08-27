using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.Repository.Identity.Security.Contracts;

namespace TestCase.Repository.Identity.Managers
{
    /// <summary>
    /// Test case user manager.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.UserManager{TestCase.DataAccess.Entities.Identity.UserEntity, System.Guid}" />
    public class TestCaseUserManager : UserManager<UserEntity, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseUserManager" /> class.
        /// </summary>
        /// <param name="store">The IUserStore is responsible for commiting changes via the UpdateAsync/CreateAsync methods</param>
        /// <param name="userValidatorFactory">The user validator factory.</param>
        /// <param name="passwordValidator">The password validator.</param>
        /// <param name="passwordHasher">The password hasher.</param>
        public TestCaseUserManager(
            IUserStore<UserEntity, Guid> store,
            IIdentityUserValidatorFactory userValidatorFactory,
            IIdentityValidator<string> passwordValidator,
            IPasswordHasher passwordHasher)
            : base(store)
        {
            this.UserValidator = userValidatorFactory.Create(this);
            this.PasswordValidator = passwordValidator;
            this.PasswordHasher = passwordHasher;
        }
    }
}
