using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

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
            RegisterWebApiRoutes(config);
            RegisterWebApiFilters(config);
            RegisterWebApiFormatters(config);
        }

        private static void RegisterWebApiRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }

        private static void RegisterWebApiFilters(HttpConfiguration config)
        {

        }

        private static void RegisterWebApiFormatters(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
