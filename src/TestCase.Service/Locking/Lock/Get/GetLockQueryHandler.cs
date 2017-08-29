using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Core.Query;
using TestCase.Repository.Locking.Contracts;

namespace TestCase.Service.Locking.Lock.Get
{
    /// <summary>
    /// Get lock query handler.
    /// </summary>
    /// <seealso cref="TestCase.Core.Query.IQueryHandler{TestCase.Service.Locking.Lock.Get.GetLockQuery, TestCase.Service.Locking.Lock.Get.GetLockResult}" />
    public class GetLockQueryHandler : IQueryHandler<GetLockQuery, GetLockResult>
    {
        private readonly ILockRepository lockRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLockQueryHandler" /> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetLockQueryHandler(ILockRepository lockRepository, IMapper mapper)
        {
            this.lockRepository = lockRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public async Task<GetLockResult> HandleAsync(GetLockQuery query)
        {
            var @lock = await this.lockRepository.GetLockAsync(query.LockId);

            return this.mapper.Map<TestCase.Model.Locking.Lock, GetLockResult>(@lock);
        }
    }
}
