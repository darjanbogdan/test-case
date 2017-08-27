using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestCase.Core.Command;
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
        ICommandHandler<RegisterUserCommand> registerUserHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="registerUserHandler">The register user handler.</param>
        public AccountController(ICommandHandler<RegisterUserCommand> registerUserHandler)
        {
            this.registerUserHandler = registerUserHandler;
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
            var command = new RegisterUserCommand
            {
                ConfirmPassword = registerUser.ConfirmPassword,
                Email = registerUser.Email,
                Password = registerUser.Password,
                UserName = registerUser.UserName
            };

            await this.registerUserHandler.HandleAsync(command);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /// <summary>
        /// Register user REST model.
        /// </summary>
        public class RegisterUser
        {
            public string UserName { get; set; }

            public string Password { get; set; }

            public string ConfirmPassword { get; set; }

            public string Email { get; set; }
        }
    }
}