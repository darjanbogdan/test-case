using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DAL.Entities.Identity;
using System.Data.Entity;

namespace TestCase.DAL.Identity.Stores
{
    /// <summary>
    /// Test case user store.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.UserStore{TestCase.DAL.Entities.Identity.UserEntity, TestCase.DAL.Entities.Identity.RoleEntity, System.Guid, TestCase.DAL.Entities.Identity.UserLoginEntity, TestCase.DAL.Entities.Identity.UserRoleEntity, TestCase.DAL.Entities.Identity.UserClaimEntity}" />
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
