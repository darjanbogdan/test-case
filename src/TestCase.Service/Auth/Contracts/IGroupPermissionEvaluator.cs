using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;

namespace TestCase.Service.Auth.Contracts
{
    /// <summary>
    /// Authorization evaluator contract.
    /// </summary>
    public interface IGroupPermissionEvaluator
    {
        /// <summary>
        /// Asynchronously evaluates the group permissions for give model.
        /// </summary>
        /// <param name="authorizeModel">The authorize model.</param>
        /// <returns></returns>
        Task EvaluateAsync(IAuthorizeModel authorizeModel);
    }
}
