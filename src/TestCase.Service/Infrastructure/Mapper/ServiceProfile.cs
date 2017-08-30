using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Model.Locking;
using TestCase.Service.Locking.Lock.CreateLockPermission;
using TestCase.Service.Locking.Lock.GetLock;

namespace TestCase.Service.Infrastructure.Mapper
{
    /// <summary>
    /// Service mapping profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile() 
            : base(nameof(ServiceProfile))
        {
            CreateMap<CreateLockPermissionCommand, LockPermissionPolicy>()
                .ForMember(d => d.Permission, opt => opt.Ignore());
        }
    }
}
