using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using TestCase.WebApi.Infrastructure.Filters;

namespace TestCase
{
    /// <summary>
    /// Web Api configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            SetupContentNegotiation(config);
            RegisterWebApiRoutes(config);
            RegisterWebApiFilters(config);
        }

        private static void RegisterWebApiRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }

        private static void RegisterWebApiFilters(HttpConfiguration config)
        {
            config.Filters.Add(new ExceptionFilter());
        }

        private static void SetupContentNegotiation(HttpConfiguration config)
        {
            var jsonFormatter = createInitializedJsonFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            JsonMediaTypeFormatter createInitializedJsonFormatter()
            {
                var formatter = new JsonMediaTypeFormatter();

                //Formatting
#if DEBUG
                formatter.SerializerSettings.Formatting = Formatting.Indented;
#else
                jsonFormatter.SerializerSettings.Formatting = Formatting.None;
#endif
                formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                //Dates
                formatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                formatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

                return formatter;
            }
        }

        private class JsonContentNegotiator : IContentNegotiator
        {
            private readonly JsonMediaTypeFormatter _jsonFormatter;

            public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
            {
                _jsonFormatter = formatter;
            }

            public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
            {
                // Only allow json content
                var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
                return result;
            }
        }
    }
}
