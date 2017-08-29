using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Locking.Maps
{
    /// <summary>
    /// Lock location entity.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Locking.LockLocationEntity}" />
    public class LockLocationEntityMap : EntityTypeConfiguration<LockLocationEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LockLocationEntityMap"/> class.
        /// </summary>
        public LockLocationEntityMap()
        {
            ToTable("LockLocation");

            HasKey(e => e.Id);

            Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(1000);

            Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(e => e.Locks)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);
        }
    }
}
