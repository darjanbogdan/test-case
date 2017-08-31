using AutoMapper;
using FluentValidation;
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
        private readonly IUserRepository userRepository;
        private readonly IRoleLookup roleLookup;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserCommandHandler" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="roleLookup">The role lookup.</param>
        /// <param name="mapper">The mapper.</param>
        public RegisterUserCommandHandler(IUserRepository userRepository, IRoleLookup roleLookup, IMapper mapper)
        {
            this.userRepository = userRepository;
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
            var user = this.mapper.Map<RegisterUserCommand, User>(registerUserCommand);
            user.Id = Guid.NewGuid(); //TODO: Should be replaced with sequential guid
            user.EmailConfirmed = true; //TODO: Should be replaced with activation logic

            try
            {
                await this.userRepository.RegisterAsync(user, registerUserCommand.Password);
            }
            catch (ArgumentException ex)
            {
                throw new ValidationException(ex.Message); //Should be relocated into validator
            }

            var userRole = await this.roleLookup.GetUserRoleAsync();

            await this.userRepository.InsertUserRolesAsync(user.Id, userRole);
        }
    }
}
