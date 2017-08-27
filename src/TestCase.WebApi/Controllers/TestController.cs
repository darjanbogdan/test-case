using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestCase.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        [Route("")]
        [HttpGet]
        public Task<HttpResponseMessage> TestAsync()
        {
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, "it works"));
        }
    }
}
