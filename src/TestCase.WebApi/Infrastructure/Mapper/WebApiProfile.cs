using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCase.Service.Membership.Registration;
using TestCase.WebApi.Controllers;

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
        }
    }
}