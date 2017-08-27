using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Repository.Infrastructure.Mapper
{
    /// <summary>
    /// Repository mapping profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class RepositoryProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryProfile"/> class.
        /// </summary>
        public RepositoryProfile() 
            : base(nameof(RepositoryProfile))
        {

        }
    }
}
