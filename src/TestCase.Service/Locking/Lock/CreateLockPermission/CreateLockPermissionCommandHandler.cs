using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Command;
using TestCase.Model.Locking;
using TestCase.Repository.Locking.Contracts;
using TestCase.Repository.Membership.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;
using TestCase.Service.Security.Lookups.Contracts;

namespace TestCase.Service.Locking.Lock.CreateLockPermission
{
    /// <summary>
    /// Create lock permission command handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Command.ICommandHandler{TestCase.Service.Locking.Lock.CreateLockPermission.CreateLockPermissionCommand}" />
    public class CreateLockPermissionCommandHandler : ICommandHandler<CreateLockPermissionCommand>
    {
        private readonly ILockRepository lockRepository;
        private readonly IUserRepository userRepository;
        private readonly IRoleLookup roleLookup;
        private readonly IPermissionLookup permissionLookup;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLockPermissionCommandHandler" /> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="roleLookup">The role lookup.</param>
        /// <param name="permissionLookup">The permission lookup.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateLockPermissionCommandHandler(
            ILockRepository lockRepository, 
            IUserRepository userRepository,
            IRoleLookup roleLookup,
            IPermissionLookup permissionLookup,
            IMapper mapper)
        {
            this.lockRepository = lockRepository;
            this.userRepository = userRepository;
            this.roleLookup = roleLookup;
            this.permissionLookup = permissionLookup;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task HandleAsync(CreateLockPermissionCommand command)
        {
            var entity = this.mapper.Map<LockPermissionPolicy>(command);
            entity.Id = Guid.NewGuid();
            entity.PermissionId = (await this.permissionLookup.GetAsync(command.Permission)).Id;

            if (!String.IsNullOrEmpty(command.UserName))
            {
                entity.UserId = (await this.userRepository.GetAsync(command.UserName)).Id;
            }
            else if (!String.IsNullOrEmpty(command.Role))
            {
                entity.RoleId = (await this.roleLookup.GetAsync(command.Role)).Id;
            }

            await this.lockRepository.InsertLockPermissionPolicyAsync(entity);
        }
    }
}
