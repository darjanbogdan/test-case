namespace TestCase.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestCase.DataAccess.Entities.Identity;
    using TestCase.DataAccess.Entities.Locking;
    using TestCase.DataAccess.Entities.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<TestCase.DataAccess.Context.TestCaseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestCase.DataAccess.Context.TestCaseDbContext context)
        {

            var adminRole = new RoleEntity() { Id = Guid.NewGuid(), Name = "Admin" };
            var userRole = new RoleEntity() { Id = Guid.NewGuid(), Name = "User" };
            context.Roles.AddOrUpdate(r => r.Name, adminRole, userRole);

            var admin = new UserEntity() { Id = Guid.NewGuid(), UserName = "admin", Email = "admin@gmail.com", PasswordHash = "123456", EmailConfirmed = true, SecurityStamp = Guid.NewGuid().ToString("D") };
            admin.Roles.Add(new UserRoleEntity() { RoleId = adminRole.Id, UserId = admin.Id });
            context.Users.AddOrUpdate(r => r.UserName, admin);

            var createPermission = new PermissionEntity() { Id = Guid.NewGuid(), Name = "Create", Abrv = "create", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            var readPermission = new PermissionEntity() { Id = Guid.NewGuid(), Name = "Read", Abrv = "read", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            var updatePermission = new PermissionEntity() { Id = Guid.NewGuid(), Name = "Update", Abrv = "update", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            var deletePermission = new PermissionEntity() { Id = Guid.NewGuid(), Name = "Delete", Abrv = "delete", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            var fullPermission = new PermissionEntity() { Id = Guid.NewGuid(), Name = "Full", Abrv = "full", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };

            context.Permissions.AddOrUpdate(p => p.Abrv, createPermission, readPermission, updatePermission, deletePermission, fullPermission);

            var userPermissionGroup = new PermissionGroupEntity() { Id = Guid.NewGuid(), Name = "UserGroup", Abrv = "user-group", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            var lockPermissionGroup = new PermissionGroupEntity() { Id = Guid.NewGuid(), Name = "LockGroup", Abrv = "lock-group", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            var lockEventPermissionGroup = new PermissionGroupEntity() { Id = Guid.NewGuid(), Name = "LockEventGroup", Abrv = "lock-event-group", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow };
            context.PermissionGroups.AddOrUpdate(pg => pg.Abrv, userPermissionGroup, lockPermissionGroup, lockEventPermissionGroup);

            context.PermissionPolicies.AddOrUpdate(pp => new { pp.PermissionGroupId, pp.PermissionId },
                new PermissionPolicyEntity() { Id = Guid.NewGuid(), RoleId = adminRole.Id, PermissionId = createPermission.Id, PermissionGroupId = lockPermissionGroup.Id, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionPolicyEntity() { Id = Guid.NewGuid(), RoleId = adminRole.Id, PermissionId = updatePermission.Id, PermissionGroupId = lockPermissionGroup.Id, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionPolicyEntity() { Id = Guid.NewGuid(), RoleId = adminRole.Id, PermissionId = readPermission.Id, PermissionGroupId = lockPermissionGroup.Id, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionPolicyEntity() { Id = Guid.NewGuid(), RoleId = adminRole.Id, PermissionId = deletePermission.Id, PermissionGroupId = lockPermissionGroup.Id, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionPolicyEntity() { Id = Guid.NewGuid(), RoleId = userRole.Id, PermissionId = createPermission.Id, PermissionGroupId = lockPermissionGroup.Id, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow }
            );

            context.LockEventTypes.AddOrUpdate(le => le.Abrv,
                new LockEventTypeEntity() { Id = Guid.NewGuid(), Name = "Unlocked", Abrv = "unlocked", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new LockEventTypeEntity() { Id = Guid.NewGuid(), Name = "Locked", Abrv = "locked", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new LockEventTypeEntity() { Id = Guid.NewGuid(), Name = "Access Granted", Abrv = "access-granted", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new LockEventTypeEntity() { Id = Guid.NewGuid(), Name = "Access Prohibited", Abrv = "access-prohibited", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow }
            );
        }
    }
}
