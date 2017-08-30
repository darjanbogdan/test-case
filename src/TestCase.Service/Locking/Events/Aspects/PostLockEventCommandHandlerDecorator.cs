using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Model.Locking;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Locking.Events.Contracts;
using TestCase.Service.Locking.Lookups.Contract;

namespace TestCase.Service.Locking.Events.Aspects
{
    /// <summary>
    /// Post lock event command handler decorator.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TCommand}" />
    public class PostLockEventCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : IPostLockEventModel
    {
        private readonly ILockEventRepository lockEventRepository;
        private readonly ILockEventTypeLookup eventTypeLookup;
        private readonly ICommandHandler<TCommand> commandHandler;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostEventCommandHandlerDecorator{TCommand}" /> class.
        /// </summary>
        /// <param name="lockEventRepository">The lock event repository.</param>
        /// <param name="commandHandler">The command handler.</param>
        public PostLockEventCommandHandlerDecorator(
            ILockEventRepository lockEventRepository, 
            ILockEventTypeLookup eventTypeLookup,
            ICommandHandler<TCommand> commandHandler,
            IMapper mapper)
        {
            this.lockEventRepository = lockEventRepository;
            this.eventTypeLookup = eventTypeLookup;
            this.commandHandler = commandHandler;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(TCommand command)
        {
            await this.commandHandler.HandleAsync(command);

            var lockEvent = this.mapper.Map<LockEvent>(command);
            lockEvent.LockEventTypeId = (await this.eventTypeLookup.GetAsync(command.LockEventType)).Id;
            lockEvent.Id = Guid.NewGuid();

            await this.lockEventRepository.InsertAsync(lockEvent);
        }
    }
}
