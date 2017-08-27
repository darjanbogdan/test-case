using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Model.Membership;
using TestCase.Repository.Membership.Contracts;

namespace TestCase.Service.Membership.Registration
{
    /// <summary>
    /// Register user command handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TestCase.Service.SimpleInjector.Membership.Registration.RegisterUserCommand}" />
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAccountRepository accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserCommandHandler"/> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        public RegisterUserCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(RegisterUserCommand registerUserCommand)
        {
            //TODO: Add mapper

            var account = new Account
            {
                UserId = Guid.NewGuid(),
                Password = registerUserCommand.Password,
                UserName = registerUserCommand.UserName,

                //TODO: Replace with activation logic
                EmailConfirmed = true
            };

            await this.accountRepository.RegisterAsync(account);

            //TODO: Add roles, claims...

        }
    }
}
