using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestCase.Core.Command;
using TestCase.Core.Context;
using TestCase.Core.Query;
using TestCase.Service.Locking.Lock.ChangeLockStatus;
using TestCase.Service.Locking.Lock.CreateLock;
using TestCase.Service.Locking.Lock.CreateLockPermission;
using TestCase.Service.Locking.Lock.DeleteLockPermission;
using TestCase.Service.Locking.Lock.GetLock;

namespace TestCase.WebApi.Controllers
{
    /// <summary>
    /// Lock controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("locks")]
    public class LockController : ApiController
    {
        private readonly ICommandHandler<CreateLockCommand> createLockHandler;
        private readonly ICommandHandler<ChangeLockStatusCommand> changeLockStatusHandler;
        private readonly ICommandHandler<CreateLockPermissionCommand> createLockPermissionHandler;
        private readonly ICommandHandler<DeleteLockPermissionCommand> deleteLockPermissionHandler;
        private readonly IExecutionContext executionContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockController" /> class.
        /// </summary>
        /// <param name="createLockHandler">The create lock handler.</param>
        /// <param name="changeLockStatusHandler">The change status handler.</param>
        /// <param name="getLockHandler">The get lock handler.</param>
        /// <param name="executionContext">The execution context.</param>
        /// <param name="mapper">The mapper.</param>
        public LockController(
            ICommandHandler<CreateLockCommand> createLockHandler,
            ICommandHandler<ChangeLockStatusCommand> changeLockStatusHandler,
            ICommandHandler<CreateLockPermissionCommand> createLockPermissionHandler,
            ICommandHandler<DeleteLockPermissionCommand> deleteLockPermissionHandler,
            IExecutionContext executionContext,
            IMapper mapper)
        {
            this.createLockHandler = createLockHandler;
            this.changeLockStatusHandler = changeLockStatusHandler;
            this.createLockPermissionHandler = createLockPermissionHandler;
            this.deleteLockPermissionHandler = deleteLockPermissionHandler;
            this.executionContext = executionContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously creates the lock.
        /// </summary>
        /// <param name="lock">The lock.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateAsync(Lock @lock)
        {
            var command = this.mapper.Map<CreateLockCommand>(@lock);
            if (command != null)
            {
                command.UserId = this.executionContext.UserInfo.UserId;
            }

            await this.createLockHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Asynchronously locks the lock.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        [Route("{lockId}/lock")]
        [HttpPut]
        public async Task<HttpResponseMessage> LockAsync(Guid lockId)
        {
            var command = new ChangeLockStatusCommand
            {
                Locked = true,
                LockId = lockId
            };

            await this.changeLockStatusHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Asynchronously unlocks the lock.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <returns></returns>
        [Route("{lockId}/unlock")]
        [HttpPut]
        public async Task<HttpResponseMessage> UnlockAsync(Guid lockId)
        {
            var command = new ChangeLockStatusCommand
            {
                Locked = false,
                LockId = lockId
            };

            await this.changeLockStatusHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Asynchronously creates the lock permission.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <param name="lockPermission">The lock permission.</param>
        /// <returns></returns>
        [Route("{lockId}/permissions")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreatePermissionAsync(Guid lockId, LockPermission lockPermission)
        {
            var command = this.mapper.Map<CreateLockPermissionCommand>(lockPermission);
            if (command != null)
            {
                command.LockId = lockId;
            }
            await this.createLockPermissionHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Asynchronously deletes the lock permission.
        /// </summary>
        /// <param name="lockId">The lock identifier.</param>
        /// <param name="lockPermission">The lock permission.</param>
        /// <returns></returns>
        [Route("{lockId}/permissions/{permissionId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePermissionAsync(Guid lockId, Guid permissionId)
        {
            var command = new DeleteLockPermissionCommand
            {
                LockId = lockId,
                LockPermissionId = permissionId
            };
            await this.deleteLockPermissionHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Lock REST model.
        /// </summary>
        public class Lock
        {
            /// <summary>
            /// Gets or sets the alias.
            /// </summary>
            public string Alias { get; set; }

            /// <summary>
            /// Gets or sets the address.
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Gets or sets the country.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            public string City { get; set; }
        }

        public class LockPermission
        {
            /// <summary>
            /// Gets the role.
            /// </summary>
            public string Role { get; set; }

            /// <summary>
            /// Gets or sets the name of the user.
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Gets the permission.
            /// </summary>
            public string Permission { get; set; }
        }
    }
}