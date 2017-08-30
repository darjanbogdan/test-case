using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Query;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.GetLock
{
    /// <summary>
    /// Get lock query handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Query.IQueryHandler{TestCase.Service.Locking.Lock.Get.GetLockQuery, TestCase.Service.Locking.Lock.Get.GetLockResult}" />
    public class GetLockQueryHandler : IQueryHandler<GetLockQuery, GetLockResult>
    {
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLockQueryHandler" /> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetLockQueryHandler(ILockRepository lockRepository)
        {
            this.lockRepository = lockRepository;
        }

        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<GetLockResult> HandleAsync(GetLockQuery query)
        {
            return new GetLockResult
            {
                Lock = await this.lockRepository.GetLockAsync(query.LockId)
            };
        }
    }
}
