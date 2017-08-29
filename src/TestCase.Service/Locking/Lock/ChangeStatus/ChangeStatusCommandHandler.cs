using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.ChangeStatus
{
    /// <summary>
    /// Change status command handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TestCase.Service.Locking.Lock.ChangeStatus.ChangeStatusCommand}" />
    public class ChangeStatusCommandHandler : ICommandHandler<ChangeStatusCommand>
    {
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        public ChangeStatusCommandHandler(ILockRepository lockRepository)
        {
            this.lockRepository = lockRepository;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(ChangeStatusCommand command)
        {
            var entity = await this.lockRepository.GetLockAsync(command.LockId);
            entity.Locked = command.Locked;
            await this.lockRepository.UpdateLockAsync(entity);
        }
    }
}
