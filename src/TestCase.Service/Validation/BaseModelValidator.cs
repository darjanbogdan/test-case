using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Validation;

namespace TestCase.Service.Validation
{
    /// <summary>
    /// Base model validator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FluentValidation.AbstractValidator{T}" />
    /// <seealso cref="TestCase.Core.Validation.IModelValidator{T}" />
    public class BaseModelValidator<T> : AbstractValidator<T>, IModelValidator<T> where T : IValidateModel
    {
        /// <summary>
        /// Asynchronously validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task ValidateAsync(T model)
        {
            if (model == null) throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure(nameof(model), "Model is required") });

            var result = Validate(model);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return Task.CompletedTask;
        }
    }
}
