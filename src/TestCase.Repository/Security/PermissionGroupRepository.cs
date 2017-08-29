using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Contracts;
using TestCase.DataAccess.Entities.Security;
using TestCase.Model.Security;
using TestCase.Repository.Security.Contracts;

namespace TestCase.Repository.Security
{
    /// <summary>
    /// Permission group repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Security.Contracts.IPermissionGroupRepository" />
    public class PermissionGroupRepository : IPermissionGroupRepository
    {
        private readonly IGenericRepository<PermissionGroupEntity> genericRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionGroupRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public PermissionGroupRepository(IGenericRepository<PermissionGroupEntity> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously gets all permission groups.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<PermissionGroup>> GetAllAsync()
        {
            var entites = await this.genericRepository.GetAllAsync();
            return this.mapper.Map<List<PermissionGroup>>(entites);
        }
    }
}
