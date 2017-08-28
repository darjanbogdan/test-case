using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Security.Maps
{
    /// <summary>
    /// Permission policy entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Permission.PermissionPolicyEntity}" />
    public class PermissionPolicyEntityMap : EntityTypeConfiguration<PermissionPolicyEntity>
    {
        public PermissionPolicyEntityMap()
        {
            ToTable("PermissionPolicy");

            HasKey(e => e.Id);

            HasRequired(e => e.Permission)
                .WithMany()
                .HasForeignKey(e => e.PermissionId);

            HasRequired(e => e.PermissionGroup)
                .WithMany()
                .HasForeignKey(e => e.PermissionGroupId);

            HasOptional(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId);

            HasOptional(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
        }
    }
}
