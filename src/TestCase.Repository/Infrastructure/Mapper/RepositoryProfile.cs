using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.DataAccess.Entities.Identity;
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
            var accountToUserMap = CreateMap<Account, UserEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));

            var userToAccountMap = CreateMap<UserEntity, Account>()
               .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
               .ForMember(d => d.Password, opt => opt.MapFrom(s => s.PasswordHash));
        }
    }
}
