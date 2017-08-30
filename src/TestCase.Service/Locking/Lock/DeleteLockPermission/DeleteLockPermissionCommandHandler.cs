using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.DeleteLockPermission
{
    /// <summary>
    /// Delete lock permission command handler.
    /// </summary>
    public class DeleteLockPermissionCommandHandler : ICommandHandler<DeleteLockPermissionCommand>
    {
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLockPermissionCommandHandler"/> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        public DeleteLockPermissionCommandHandler(ILockRepository lockRepository)
        {
            this.lockRepository = lockRepository;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public Task HandleAsync(DeleteLockPermissionCommand command)
        {
            return this.lockRepository.DeleteLockPermissionAsync(command.LockPermissionId);
        }
    }
}
