using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.ChangeLockStatus
{
    /// <summary>
    /// Change lock status command handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TestCase.Service.Locking.Lock.ChangeStatus.ChangeStatusCommand}" />
    public class ChangeLockStatusCommandHandler : ICommandHandler<ChangeLockStatusCommand>
    {
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeLockStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        public ChangeLockStatusCommandHandler(ILockRepository lockRepository)
        {
            this.lockRepository = lockRepository;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(ChangeLockStatusCommand command)
        {
            var entity = await this.lockRepository.GetLockAsync(command.LockId);
            entity.Locked = command.Locked;
            await this.lockRepository.UpdateLockAsync(entity);
        }
    }
}
