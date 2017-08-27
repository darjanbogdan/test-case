using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestCase.Core.Command;
using TestCase.Service.Membership.Registration;

namespace TestCase.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        ICommandHandler<RegisterUserCommand> registerUserHandler;

        public TestController(ICommandHandler<RegisterUserCommand> registerUserHandler)
        {
            this.registerUserHandler = registerUserHandler;
        }

        [Route("")]
        [HttpGet]
        public Task<HttpResponseMessage> TestAsync()
        {
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, "it works."));
        }
    }
}
