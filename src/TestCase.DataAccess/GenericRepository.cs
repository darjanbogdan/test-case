using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Contracts;

namespace TestCase.DataAccess
{
    /// <summary>
    /// Generic repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="TestCase.DataAccess.Contracts.IGenericRepository{TEntity}" />
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Asynchronously deletes the entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid entityId)
        {
            TEntity entity = new TEntity() { Id = entityId };

            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Deleted;
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously finds the entites.
        /// </summary>
        /// <returns></returns>
        public Task<IQueryable<TEntity>> FindAsync()
        {
            return Task.FromResult(this.context.Set<TEntity>().AsQueryable());
        }

        /// <summary>
        /// Asynchronously gets all entities.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().AsNoTracking().Where(p => p != null).ToListAsync();
        }

        /// <summary>
        /// Asynchronously gets the entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Guid entityId)
        {
            return await this.context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == entityId);
        }

        /// <summary>
        /// Asynchronously inserts the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task InsertAsync(TEntity entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateUpdated = DateTime.UtcNow;

            this.context.Set<TEntity>().Add(entity);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity)
        {
            entity.DateUpdated = DateTime.UtcNow;

            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;
            this.context.Entry<TEntity>(entity).Property(x => x.DateCreated).IsModified = false;
            await this.context.SaveChangesAsync();
        }
    }
}
