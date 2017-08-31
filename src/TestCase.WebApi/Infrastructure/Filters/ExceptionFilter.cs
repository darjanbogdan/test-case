using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using TestCase.Service.Infrastructure.Exceptions;

namespace TestCase.WebApi.Infrastructure.Filters
{
    /// <summary>
    /// Exception filter.
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ExceptionFilterAttribute" />
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException)
            {
                return;
            }

            var statusCode = HttpStatusCode.InternalServerError;
            if (context.Exception is ValidationException)
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }
            context.Response = context.Request.CreateErrorResponse(statusCode, context.Exception);
        }
    }
}