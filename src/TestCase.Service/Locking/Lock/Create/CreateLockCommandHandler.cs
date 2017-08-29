using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Model.Locking;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.Create
{
    /// <summary>
    /// Create lock command handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TestCase.Service.Locking.Lock.Create.CreateLockCommand}" />
    public class CreateLockCommandHandler : ICommandHandler<CreateLockCommand>
    {
        private readonly ILockRepository lockRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLockCommandHandler" /> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateLockCommandHandler(ILockRepository lockRepository, IMapper mapper)
        {
            this.lockRepository = lockRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(CreateLockCommand command)
        {
            var lockLocation = this.mapper.Map<LockLocation>(command);
            lockLocation.Id = Guid.NewGuid();

            var @lock = this.mapper.Map<Model.Locking.Lock>(command);
            @lock.Id = Guid.NewGuid();
            @lock.LocationId = lockLocation.Id;

            await this.lockRepository.InsertLockLocationAsync(lockLocation);

            await this.lockRepository.InsertLockAsync(@lock);
        }
    }
}
