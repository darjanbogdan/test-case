using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Validation;
using TestCase.Service.Validation;
using FluentValidation.Results;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.Create
{
    /// <summary>
    /// Create lock command validator
    /// </summary>
    /// <seealso cref="TestCase.Service.Validation.BaseModelValidator{TestCase.Service.Locking.Lock.Create.CreateLockCommand}" />
    public class CreateLockCommandValidator : BaseModelValidator<CreateLockCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLockCommandValidator" /> class.
        /// </summary>
        public CreateLockCommandValidator(ILockRepository lockRepository)
        {
            RuleFor(model => model.Alias)
                .NotEmpty().WithMessage("Alias is required.")
                .Length(1, 250).WithMessage("Address is out of range.");
            RuleFor(model => model.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(1, 1000).WithMessage("Address is out of range.");
            RuleFor(model => model.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(1, 100).WithMessage("City is out of range.");
            RuleFor(model => model.Country)
                .NotEmpty().WithMessage("Country is required.")
                .Length(1, 100).WithMessage("Country is out of range.");
            RuleFor(model => model.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
