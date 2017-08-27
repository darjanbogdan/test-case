using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using System.Data.Entity;

namespace TestCase.DataAccess.Identity.Stores
{
    /// <summary>
    /// Test case user store.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.UserStore{TestCase.DataAccess.Entities.Identity.UserEntity, TestCase.DataAccess.Entities.Identity.RoleEntity, System.Guid, TestCase.DataAccess.Entities.Identity.UserLoginEntity, TestCase.DataAccess.Entities.Identity.UserRoleEntity, TestCase.DataAccess.Entities.Identity.UserClaimEntity}" />
    public class TestCaseUserStore : UserStore<UserEntity, RoleEntity, Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseUserStore"/> class.
        /// </summary>
        /// <param name="context"></param>
        public TestCaseUserStore(DbContext context) 
            : base(context)
        {
        }
    }
}
