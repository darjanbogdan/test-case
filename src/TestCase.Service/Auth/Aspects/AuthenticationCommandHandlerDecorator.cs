using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Auth;
using TestCase.Core.Command;
using TestCase.Core.Context;

namespace TestCase.Service.Auth.Aspects
{
    /// <summary>
    /// Authentication command handler decorator.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TCommand}" />
    public class AuthenticationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IAuthenticateModel
    {
        private readonly IExecutionContext executionContext;
        private readonly ICommandHandler<TCommand> commandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationCommandHandlerDecorator{TCommand}"/> class.
        /// </summary>
        /// <param name="commandHandler">The command handler.</param>
        public AuthenticationCommandHandlerDecorator(IExecutionContext executionContext, ICommandHandler<TCommand> commandHandler)
        {
            this.executionContext = executionContext;
            this.commandHandler = commandHandler;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public Task HandleAsync(TCommand command)
        {
            if (!this.executionContext.UserInfo.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("Not Authenticated");
            }
            return this.commandHandler.HandleAsync(command);
        }
    }
}
