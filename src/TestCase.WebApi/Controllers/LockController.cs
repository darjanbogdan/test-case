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
using TestCase.Service.Locking.Lock.ChangeStatus;
using TestCase.Service.Locking.Lock.Create;
using TestCase.Service.Locking.Lock.Get;

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
        private readonly ICommandHandler<ChangeStatusCommand> changeStatusHandler;
        private readonly IQueryHandler<GetLockQuery, GetLockResult> getLockHandler;
        private readonly IExecutionContext executionContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LockController" /> class.
        /// </summary>
        /// <param name="createLockHandler">The create lock handler.</param>
        /// <param name="changeStatusHandler">The change status handler.</param>
        /// <param name="getLockHandler">The get lock handler.</param>
        /// <param name="executionContext">The execution context.</param>
        /// <param name="mapper">The mapper.</param>
        public LockController(
            ICommandHandler<CreateLockCommand> createLockHandler,
            ICommandHandler<ChangeStatusCommand> changeStatusHandler,
            IQueryHandler<GetLockQuery, GetLockResult> getLockHandler,
            IExecutionContext executionContext,
            IMapper mapper)
        {
            this.createLockHandler = createLockHandler;
            this.changeStatusHandler = changeStatusHandler;
            this.getLockHandler = getLockHandler;
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
            command.UserId = this.executionContext.UserInfo.UserId;

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
            //var existingLock = await this.getLockHandler.HandleAsync(new GetLockQuery() { LockId = lockId });
            //if (existingLock == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            var command = new ChangeStatusCommand
            {
                Locked = true,
                LockId = lockId
            };

            await this.changeStatusHandler.HandleAsync(command);

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
            var command = new ChangeStatusCommand
            {
                Locked = false,
                LockId = lockId
            };

            await this.changeStatusHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.NoContent);
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
    }
}