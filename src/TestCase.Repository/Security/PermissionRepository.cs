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
    /// Permission repository.
    /// </summary>
    /// <seealso cref="TestCase.Repository.Security.Contracts.IPermissionRepository" />
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IGenericRepository<PermissionEntity> genericRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        public PermissionRepository(IGenericRepository<PermissionEntity> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously gets all permissions.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            var entites = await this.genericRepository.GetAllAsync();
            return this.mapper.Map<List<Permission>>(entites);
        }
    }
}
