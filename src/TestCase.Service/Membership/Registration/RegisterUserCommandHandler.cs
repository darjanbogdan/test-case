using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Model.Membership;
using TestCase.Repository.Membership.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;

namespace TestCase.Service.Membership.Registration
{
    /// <summary>
    /// Register user command handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TestCase.Service.SimpleInjector.Membership.Registration.RegisterUserCommand}" />
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IRoleLookup roleLookup;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserCommandHandler" /> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="roleLookup">The role lookup.</param>
        /// <param name="mapper">The mapper.</param>
        public RegisterUserCommandHandler(IAccountRepository accountRepository, IRoleLookup roleLookup, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.roleLookup = roleLookup;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(RegisterUserCommand registerUserCommand)
        {
            var account = this.mapper.Map<RegisterUserCommand, Account>(registerUserCommand);
            account.UserId = Guid.NewGuid(); //TODO: Replace with sequential guid
            account.EmailConfirmed = true; //TODO: Replace with activation logic
        
            await this.accountRepository.RegisterAsync(account);

            var userRole = await this.roleLookup.GetUserRoleAsync();

            await this.accountRepository.InsertUserRolesAsync(account.UserId, userRole);
        }
    }
}
