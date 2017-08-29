using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Locking.Maps
{
    /// <summary>
    /// Lock permission policy entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Locking.Maps.LockPermissionPolicyEntityMap}" />
    public class LockPermissionPolicyEntityMap : EntityTypeConfiguration<LockPermissionPolicyEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LockPermissionPolicyEntityMap" /> class.
        /// </summary>
        public LockPermissionPolicyEntityMap()
        {
            ToTable("LockPermissionPolicy");

            HasKey(e => e.Id);

            HasRequired(e => e.Lock)
                .WithMany()
                .HasForeignKey(e => e.LockId);

            HasRequired(e => e.Permission)
                .WithMany()
                .HasForeignKey(e => e.PermissionId);

            HasOptional(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            HasOptional(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId);
        }
    }
}
