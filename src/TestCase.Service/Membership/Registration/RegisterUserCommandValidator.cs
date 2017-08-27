using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Validation;
using TestCase.Service.Aspects.Validation;

namespace TestCase.Service.Membership.Registration
{
    /// <summary>
    /// Register user command validator.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{TestCase.Service.Membership.Registration.RegisterUserCommand}" />
    /// <seealso cref="TestCase.Core.Validation.IModelValidator{TestCase.Service.Membership.Registration.RegisterUserCommand}" />
    public class RegisterUserCommandValidator : BaseModelValidator<RegisterUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserCommandValidator"/> class.
        /// </summary>
        public RegisterUserCommandValidator()
        {
            RuleFor(model => model.UserName)
                .NotEmpty().WithMessage("UserName is required.");

            RuleFor(model => model.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email has wrong format.")
                .Length(3, 256).WithMessage("Email is out of range.");

            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(model => model.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword is required.")
                .Must((command, field) =>
                {
                    return field == command.Password;
                }).WithMessage("Confirm password isn't correct.");
        }

    }
}
