namespace TestCase.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestCase.DataAccess.Entities.Identity;
    using TestCase.DataAccess.Entities.Permission;

    internal sealed class Configuration : DbMigrationsConfiguration<TestCase.DataAccess.Context.TestCaseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestCase.DataAccess.Context.TestCaseDbContext context)
        {

            var adminRoleId = Guid.NewGuid();
            context.Roles.AddOrUpdate(r => r.Name,
                new RoleEntity() { Id = adminRoleId, Name = "Admin" },
                new RoleEntity() { Id = Guid.NewGuid(), Name = "User" }
            );

            var adminId = Guid.NewGuid();
            var adminEntity = new UserEntity() { Id = adminId, UserName = "admin", Email = "admin@gmail.com", PasswordHash = "123456", EmailConfirmed = true, SecurityStamp = Guid.NewGuid().ToString("D") };
            adminEntity.Roles.Add(new UserRoleEntity() { RoleId = adminRoleId, UserId = adminId });
            context.Users.AddOrUpdate(r => r.UserName, adminEntity);

            context.Permission.AddOrUpdate(p => p.Abrv,
                new PermissionEntity() { Id = Guid.NewGuid(), Name = "Create", Abrv = "create", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionEntity() { Id = Guid.NewGuid(), Name = "Read", Abrv = "read", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionEntity() { Id = Guid.NewGuid(), Name = "Update", Abrv = "update", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionEntity() { Id = Guid.NewGuid(), Name = "Delete", Abrv = "delete", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionEntity() { Id = Guid.NewGuid(), Name = "Full", Abrv = "full", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow }
            );

            context.PermissionGroup.AddOrUpdate(pg => pg.Abrv,
                new PermissionGroupEntity() { Id = Guid.NewGuid(), Name = "UserGroup", Abrv = "user-group", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
                new PermissionGroupEntity() { Id = Guid.NewGuid(), Name = "LockGroup", Abrv = "LockGroup", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow }
            );
        }
    }
}
