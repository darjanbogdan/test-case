using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Locking.Maps
{
    /// <summary>
    /// Lock entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Locking.LockEntity}" />
    public class LockEntityMap : EntityTypeConfiguration<LockEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LockEntityMap"/> class.
        /// </summary>
        public LockEntityMap()
        {
            ToTable("Lock");

            HasKey(e => e.Id);

            HasRequired(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId);

            HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            Property(e => e.Alias)
                .IsRequired()
                .HasMaxLength(250);

            Property(e => e.Locked)
                .IsRequired();
        }
    }
}
