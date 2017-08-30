using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCase.Service.Membership.Registration;
using TestCase.WebApi.Controllers;
using static TestCase.WebApi.Controllers.LockController;

namespace TestCase.WebApi.Infrastructure.Mapper
{
    /// <summary>
    /// Web api profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class WebApiProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiProfile"/> class.
        /// </summary>
        public WebApiProfile()
            : base(nameof(WebApiProfile))
        {
            CreateMap<Model.Locking.Lock, Lock>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Location.Address))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.Location.City))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Location.Country))
                .ForMember(d => d.Events, opt => opt.MapFrom(s => s.Events));

            CreateMap<Model.Locking.LockEvent, LockEvent>()
                .ForMember(d => d.DateOccured, opt => opt.MapFrom(s => s.DateCreated))
                .ForMember(d => d.LockEventType, opt => opt.MapFrom(s => s.LockEventType.Name));
        }
    }
}