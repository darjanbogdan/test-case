using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Security.Maps
{
    /// <summary>
    /// Permission entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Permission.PermissionEntity}" />
    public class PermissionEntityMap : EntityTypeConfiguration<PermissionEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionEntityMap"/> class.
        /// </summary>
        public PermissionEntityMap()
        {
            ToTable("Permission");

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
