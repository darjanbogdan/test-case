using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.DataAccess.Entities.Locking;
using TestCase.DataAccess.Entities.Locking.Maps;
using TestCase.DataAccess.Entities.Security;
using TestCase.DataAccess.Entities.Security.Maps;
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

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        public IDbSet<PermissionEntity> Permissions { get; set; }

        /// <summary>
        /// Gets or sets the permission policy.
        /// </summary>
        public IDbSet<PermissionPolicyEntity> PermissionPolicies { get; set; }

        /// <summary>
        /// Gets or sets the permission group.
        /// </summary>
        public IDbSet<PermissionGroupEntity> PermissionGroups { get; set; }

        /// <summary>
        /// Gets or sets the lock.
        /// </summary>
        public IDbSet<LockEntity> Locks { get; set; }

        /// <summary>
        /// Gets or sets the lock event.
        /// </summary>
        public IDbSet<LockEventEntity> LockEvents { get; set; }

        /// <summary>
        /// Gets or sets the type of the lock event.
        /// </summary>
        public IDbSet<LockEventTypeEntity> LockEventTypes { get; set; }

        /// <summary>
        /// Gets or sets the lock locations.
        /// </summary>
        public IDbSet<LockLocationEntity> LockLocations { get; set; }

        /// <summary>
        /// Gets or sets the lock permission policies.
        /// </summary>
        public IDbSet<LockPermissionPolicyEntity> LockPermissionPolicies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PermissionEntityMap());
            modelBuilder.Configurations.Add(new PermissionPolicyEntityMap());
            modelBuilder.Configurations.Add(new PermissionGroupEntityMap());

            modelBuilder.Configurations.Add(new LockEntityMap());
            modelBuilder.Configurations.Add(new LockEventEntityMap());
            modelBuilder.Configurations.Add(new LockEventTypeEntityMap());
            modelBuilder.Configurations.Add(new LockLocationEntityMap());
            modelBuilder.Configurations.Add(new LockPermissionPolicyEntityMap());
        }
    }
}
