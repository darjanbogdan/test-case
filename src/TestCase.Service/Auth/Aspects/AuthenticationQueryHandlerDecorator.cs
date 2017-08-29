using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Context;
using TestCase.Core.Query;

namespace TestCase.Service.Auth.Aspects
{
    /// <summary>
    /// Authentication query handler decorator.
    /// </summary>
    public class AuthenticationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>, IAuthenticateModel
    {
        private readonly IExecutionContext executionContext;
        private readonly IQueryHandler<TQuery, TResult> queryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationQueryHandlerDecorator{TQuery, TResult}"/> class.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        /// <param name="queryHandler">The query handler.</param>
        public AuthenticationQueryHandlerDecorator(IExecutionContext executionContext, IQueryHandler<TQuery, TResult> queryHandler)
        {
            this.executionContext = executionContext;
            this.queryHandler = queryHandler;
        }

        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<TResult> HandleAsync(TQuery query)
        {
            if (!this.executionContext.UserInfo.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("Not Authenticated");
            }
            return await this.queryHandler.HandleAsync(query);
        }
    }
}
