using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Core.Validation
{
    /// <summary>
    /// Model validator contract.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelValidator<T> where T : IValidate
    {
        /// <summary>
        /// Asynchronously validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task ValidateAsync(T model);
    }
}
