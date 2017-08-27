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
    /// Test case role store.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.RoleStore{TestCase.DataAccess.Entities.Identity.RoleEntity, System.Guid, TestCase.DataAccess.Entities.Identity.UserRoleEntity}" />
    public class TestCaseRoleStore : RoleStore<RoleEntity, Guid, UserRoleEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseRoleStore"/> class.
        /// </summary>
        /// <param name="context"></param>
        public TestCaseRoleStore(DbContext context) 
            : base(context)
        {
        }
    }
}
