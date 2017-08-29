using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.DataAccess.Entities.Locking.Maps
{
    /// <summary>
    /// Lock event entity map.
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{TestCase.DataAccess.Entities.Locking.LockEventEntity}" />
    public class LockEventEntityMap : EntityTypeConfiguration<LockEventEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LockEventEntityMap"/> class.
        /// </summary>
        public LockEventEntityMap()
        {
            ToTable("LockEvent");

            HasKey(e => e.Id);

            HasRequired(e => e.Lock)
                .WithMany()
                .HasForeignKey(e => e.LockId);

            HasRequired(e => e.LockEventType)
                .WithMany()
                .HasForeignKey(e => e.LockEventTypeId);
        }
    }
}
