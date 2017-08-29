using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Locking.Maps
{
    /// <summary>
    /// Lock event type entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Locking.LockEventTypeEntity}" />
    public class LockEventTypeEntityMap : EntityTypeConfiguration<LockEventTypeEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LockEventTypeEntityMap"/> class.
        /// </summary>
        public LockEventTypeEntityMap()
        {
            ToTable("LockEventType");

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
