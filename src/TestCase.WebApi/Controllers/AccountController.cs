using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestCase.Core.Command;
using TestCase.Core.Context;
using TestCase.Service.Membership.Registration;

namespace TestCase.WebApi.Controllers
{
    /// <summary>
    /// Account controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("accounts")]
    public class AccountController : ApiController
    {
        private readonly ICommandHandler<RegisterUserCommand> registerUserHandler;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="registerUserHandler">The register user handler.</param>
        public AccountController(ICommandHandler<RegisterUserCommand> registerUserHandler, IMapper mapper)
        {
            this.registerUserHandler = registerUserHandler;
            this.mapper = mapper;
        }

        /// <summary>
        /// Asynchronously registers the user.
        /// </summary>
        /// <param name="registerUser">The register user.</param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public async Task<HttpResponseMessage> RegisterAsync(RegisterUser registerUser)
        {
            var command = this.mapper.Map<RegisterUserCommand>(registerUser);
           
            await this.registerUserHandler.HandleAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Register user REST model.
        /// </summary>
        public class RegisterUser
        {
            /// <summary>
            /// Gets or sets the name of the user.
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets the confirm password.
            /// </summary>
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            public string Email { get; set; }
        }
    }
}