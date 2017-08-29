namespace TestCase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLockRelatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LockEvent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        LockId = c.Guid(nullable: false),
                        LockEventTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lock", t => t.LockId, cascadeDelete: true)
                .ForeignKey("dbo.LockEventType", t => t.LockEventTypeId, cascadeDelete: true)
                .Index(t => t.LockId)
                .Index(t => t.LockEventTypeId);
            
            CreateTable(
                "dbo.Lock",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Locked = c.Boolean(nullable: false),
                        LocationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LockLocation", t => t.LocationId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.LockLocation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Country = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LockEventType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Abrv = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LockPermissionPolicy",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        LockId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                        UserId = c.Guid(),
                        RoleId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lock", t => t.LockId, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.LockId)
                .Index(t => t.PermissionId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LockPermissionPolicy", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LockPermissionPolicy", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LockPermissionPolicy", "PermissionId", "dbo.Permission");
            DropForeignKey("dbo.LockPermissionPolicy", "LockId", "dbo.Lock");
            DropForeignKey("dbo.LockEvent", "LockEventTypeId", "dbo.LockEventType");
            DropForeignKey("dbo.LockEvent", "LockId", "dbo.Lock");
            DropForeignKey("dbo.Lock", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lock", "LocationId", "dbo.LockLocation");
            DropIndex("dbo.LockPermissionPolicy", new[] { "RoleId" });
            DropIndex("dbo.LockPermissionPolicy", new[] { "UserId" });
            DropIndex("dbo.LockPermissionPolicy", new[] { "PermissionId" });
            DropIndex("dbo.LockPermissionPolicy", new[] { "LockId" });
            DropIndex("dbo.Lock", new[] { "LocationId" });
            DropIndex("dbo.Lock", new[] { "UserId" });
            DropIndex("dbo.LockEvent", new[] { "LockEventTypeId" });
            DropIndex("dbo.LockEvent", new[] { "LockId" });
            DropTable("dbo.LockPermissionPolicy");
            DropTable("dbo.LockEventType");
            DropTable("dbo.LockLocation");
            DropTable("dbo.Lock");
            DropTable("dbo.LockEvent");
        }
    }
}
