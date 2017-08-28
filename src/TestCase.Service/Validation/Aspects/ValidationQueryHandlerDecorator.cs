using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Query;
using TestCase.Core.Validation;

namespace TestCase.Service.Validation.Aspects
{
    /// <summary>
    /// Validation query handler decorator.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="TestCase.Core.Query.IQueryHandler{TQuery, TResult}" />
    public class ValidationQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>, IValidateModel
    {
        private readonly IModelValidator<TQuery> validator;
        private readonly IQueryHandler<TQuery, TResult> queryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationQueryHandlerDecorator{TQuery, TResult}"/> class.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="queryHandler">The query handler.</param>
        public ValidationQueryHandlerDecorator(IModelValidator<TQuery> validator, IQueryHandler<TQuery, TResult> queryHandler)
        {
            this.validator = validator;
            this.queryHandler = queryHandler;
        }

        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<TResult> HandleAsync(TQuery query)
        {
            await this.validator.ValidateAsync(query);

            return await this.queryHandler.HandleAsync(query);
        }
    }
}
