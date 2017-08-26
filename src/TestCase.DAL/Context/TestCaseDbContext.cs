using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DAL.Entities.Identity;
using TestCase.DAL.Migrations;

namespace TestCase.DAL.Context
{
    /// <summary>
    /// Test case database context.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{TestCase.DAL.Entities.Identity.UserEntity, TestCase.DAL.Entities.Identity.RoleEntity, System.Guid, TestCase.DAL.Entities.Identity.UserLoginEntity, TestCase.DAL.Entities.Identity.UserRoleEntity, TestCase.DAL.Entities.Identity.UserClaimEntity}" />
    public class TestCaseDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid, UserLoginEntity, UserRoleEntity, UserClaimEntity>
    {
        /// <summary>
        /// Initializes the <see cref="TestCaseDbContext"/> class.
        /// </summary>
        static TestCaseDbContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestCaseDbContext, Configuration>("DefaultConnection"));
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
