using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Command;
using TestCase.Service.Security.Contracts;

namespace TestCase.Service.Auth.Aspects
{
    /// <summary>
    /// Authorization command handler decorator.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TCommand}" />
    public class AuthorizationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IAuthorizeModel
    {
        private readonly IObjectPermissionEvaluator<TCommand> objectPermissionEvaluator;
        private readonly IGroupPermissionEvaluator groupPermissionEvaluator;
        private readonly ICommandHandler<TCommand> commandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationCommandHandlerDecorator{TCommand}"/> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        public AuthorizationCommandHandlerDecorator(
            IObjectPermissionEvaluator<TCommand> objectPermissionEvaluator,
            IGroupPermissionEvaluator groupPermissionEvaluator, 
            ICommandHandler<TCommand> commandHandler)
        {
            this.objectPermissionEvaluator = objectPermissionEvaluator;
            this.groupPermissionEvaluator = groupPermissionEvaluator;
            this.commandHandler = commandHandler;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(TCommand command)
        {
            var hasObjectPermissions = await this.objectPermissionEvaluator.EvaluateAsync(command);
            if (!hasObjectPermissions)
            {
                var hasGroupPermissions = await this.groupPermissionEvaluator.EvaluateAsync(command);
                if (!hasGroupPermissions)
                {
                    throw new UnauthorizedAccessException("Not Authorized");
                }
            }
            await this.commandHandler.HandleAsync(command);
        }
    }
}
