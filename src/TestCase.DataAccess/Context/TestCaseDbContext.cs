using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.DataAccess.Migrations;

namespace TestCase.DataAccess.Context
{
    /// <summary>
    /// Test case database context.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{TestCase.DataAccess.Entities.Identity.UserEntity, TestCase.DataAccess.Entities.Identity.RoleEntity, System.Guid, TestCase.DataAccess.Entities.Identity.UserLoginEntity, TestCase.DataAccess.Entities.Identity.UserRoleEntity, TestCase.DataAccess.Entities.Identity.UserClaimEntity}" />
    public class TestCaseDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
        /// <summary>
        /// Initializes the <see cref="TestCaseDbContext"/> class.
        /// </summary>
        static TestCaseDbContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestCaseDbContext, Configuration>("DefaultConnection"));

            //Note: Ensures that EntityFramework.SqlServer.dll (implicit dependency ) is copied into host's /bin folder
            var staticDependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        /// <summary>
        /// Initializes a new instance of t  he <see cref="TestCaseDbContext"/> class.
        /// </summary>
        public TestCaseDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public TestCaseDbContext(string connectionString)
            : base(connectionString)
        {
            
        }
    }
}
