using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Query
{
    /// <summary>
    /// Query handler contract.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandler<TQuery, TResult> where TQuery: IQuery<TResult>
    {
        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        Task<TResult> HandleAsync(TQuery query);
    }
}
