using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Service.Infrastructure.Lookups.Contracts
{
    /// <summary>
    /// Lookup contract.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILookup<T>
    {
        /// <summary>
        /// Asynchronously gets all lookup items.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Asynchronously gets the lookup item.
        /// </summary>
        /// <param name="abrv">The abrv.</param>
        /// <returns></returns>
        Task<T> GetAsync(string abrv);
    }
}
