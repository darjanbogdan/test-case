using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Service.Validation;

namespace TestCase.Service.Locking.Lock.Get
{
    /// <summary>
    /// Get lock query validator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Validation.BaseModelValidator{TestCase.Service.Locking.Lock.Get.GetLockQuery}" />
    public class GetLockQueryValidator : BaseModelValidator<GetLockQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLockQueryValidator"/> class.
        /// </summary>
        public GetLockQueryValidator()
        {
            RuleFor(model => model.LockId)
                .NotEmpty().WithMessage("LockId is required");
        }
    }
}
