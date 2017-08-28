using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Contracts;

namespace TestCase.DataAccess.Contracts
{
    /// <summary>
    /// Generic repository contract.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Asynchronously deletes the entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid entityId);

        /// <summary>
        /// Asynchronously gets all entities.
        /// </summary>
        /// <returns></returns>
        Task<IList<TEntity>> GetAllAsync();

        /// <summary>
        /// Asynchronously gets the entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid entityId);

        /// <summary>
        /// Asynchronously inserts the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Asynchronously updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);
    }
}
