using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Service.Security.Contracts;

namespace TestCase.Service.Security
{
    /// <summary>
    /// Null object permission evaluator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullObjectPermissionEvaluator<T> : IObjectPermissionEvaluator<T>
    {
        /// <summary>
        /// Asynchronously evaluates the object permissions for given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<bool> EvaluateAsync(T model) => Task.FromResult(true);
    }
}
