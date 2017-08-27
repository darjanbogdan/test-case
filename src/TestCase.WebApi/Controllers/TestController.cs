using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestCase.Core.Command;
using TestCase.Core.Context;
using TestCase.Service.Membership.Registration;

namespace TestCase.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        private readonly IExecutionContext executionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        public TestController(IExecutionContext executionContext)
        {
            this.executionContext = executionContext;
        }

        [Route("")]
        [HttpGet]
        public Task<HttpResponseMessage> TestAsync()
        {
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, this.executionContext.UserInfo));
        }
    }
}
