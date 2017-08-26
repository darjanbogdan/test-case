using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DAL.Entities.Identity;

namespace TestCase.DAL.Identity.Managers
{
    /// <summary>
    /// Test case user manager.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.UserManager{TestCase.DAL.Entities.Identity.UserEntity, System.Guid}" />
    public class TestCaseUserManager : UserManager<UserEntity, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseUserManager" /> class.
        /// </summary>
        /// <param name="store">The IUserStore is responsible for commiting changes via the UpdateAsync/CreateAsync methods</param>
        /// <param name="userValidator">The user validator.</param>
        /// <param name="passwordValidator">The password validator.</param>
        /// <param name="passwordHasher">The password hasher.</param>
        public TestCaseUserManager(
            IUserStore<UserEntity, Guid> store, 
            IIdentityValidator<UserEntity> userValidator, 
            IIdentityValidator<string> passwordValidator, 
            IPasswordHasher passwordHasher) 
            : base(store)
        {
            this.UserValidator = userValidator;
            this.PasswordValidator = passwordValidator;
            this.PasswordHasher = passwordHasher;
        }
    }
}
