using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Validation;

namespace TestCase.Service.Membership.Registration
{
    /// <summary>
    /// Register user command.
    /// </summary>
    public class RegisterUserCommand : IValidateModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the name of the model.
        /// </summary>
        string IValidateModel.Name => nameof(RegisterUserCommand);
    }
}
