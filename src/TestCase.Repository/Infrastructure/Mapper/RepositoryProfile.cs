using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
using TestCase.DataAccess.Entities.Locking;
using TestCase.Model.Locking;
using TestCase.Model.Membership;

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
            CreateMap<LockLocationEntity, LockLocation>()
                .ForMember(d => d.Locks, opt => opt.Ignore());

            CreateMap<LockEventEntity, LockEvent>()
                .ForMember(d => d.Lock, opt => opt.Ignore());
        }
    }
}
