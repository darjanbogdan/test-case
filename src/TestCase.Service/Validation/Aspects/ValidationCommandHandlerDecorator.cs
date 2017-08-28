using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Core.Validation;

namespace TestCase.Service.Validation.Aspects
{
    /// <summary>
    /// Validation command handler decorator.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TCommand}" />
    public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IValidateModel
    {
        private readonly IModelValidator<TCommand> validator;
        private readonly ICommandHandler<TCommand> commandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationCommandHandlerDecorator{TCommand}"/> class.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="commandHandler">The command handler.</param>
        public ValidationCommandHandlerDecorator(IModelValidator<TCommand> validator, ICommandHandler<TCommand> commandHandler)
        {
            this.validator = validator;
            this.commandHandler = commandHandler;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(TCommand command)
        {
            await this.validator.ValidateAsync(command);

            await this.commandHandler.HandleAsync(command);
        }
    }
}
