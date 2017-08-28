using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Validation;
using TestCase.Service.Validation;

namespace TestCase.Service.Membership.Login
{
    /// <summary>
    /// Get user claims identity validator.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{TestCase.Service.Membership.Login.GetUserClaimsIdentityQuery}" />
    /// <seealso cref="TestCase.Core.Validation.IModelValidator{TestCase.Service.Membership.Login.GetUserClaimsIdentityQuery}" />
    public class GetUserClaimsIdentityQueryValidator : BaseModelValidator<GetUserClaimsIdentityQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserClaimsIdentityQueryValidator"/> class.
        /// </summary>
        public GetUserClaimsIdentityQueryValidator()
        {
            RuleFor(model => model.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(model => model.UserName)
                .NotEmpty().WithMessage("UserName is required.");
        }
    }
}
