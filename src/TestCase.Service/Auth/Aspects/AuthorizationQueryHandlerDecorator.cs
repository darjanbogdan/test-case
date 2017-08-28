using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Query;
using TestCase.Service.Auth.Contracts;

namespace TestCase.Service.Auth.Aspects
{
    /// <summary>
    /// Authorization query handler decorator.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="TestCase.Core.Query.IQueryHandler{TQuery, TResult}" />
    public class AuthorizationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>, IAuthorizeModel
    {
        private readonly IGroupPermissionEvaluator groupPermissionEvaluator;
        private readonly IQueryHandler<TQuery, TResult> queryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationQueryHandlerDecorator{TQuery, TResult}"/> class.
        /// </summary>
        /// <param name="groupPermissionEvaluator">The group permission evaluator.</param>
        /// <param name="queryHandler">The query handler.</param>
        public AuthorizationQueryHandlerDecorator(IGroupPermissionEvaluator groupPermissionEvaluator, IQueryHandler<TQuery, TResult> queryHandler)
        {
            this.groupPermissionEvaluator = groupPermissionEvaluator;
            this.queryHandler = queryHandler;
        }

        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TResult> HandleAsync(TQuery query)
        {
            await this.groupPermissionEvaluator.EvaluateAsync(query);

            return await this.queryHandler.HandleAsync(query);
        }
    }
}
