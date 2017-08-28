using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Permission.Maps
{
    /// <summary>
    /// Permission group entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Permission.PermissionGroupEntity}" />
    public class PermissionGroupEntityMap : EntityTypeConfiguration<PermissionGroupEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionGroupEntityMap"/> class.
        /// </summary>
        public PermissionGroupEntityMap()
        {
            ToTable("PermissionGroup");

            HasKey(e => e.Id);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Abrv)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
