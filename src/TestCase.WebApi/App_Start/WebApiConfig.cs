using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace TestCase
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Routes
            config.MapHttpAttributeRoutes();

            //Filters

            //Formatter
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
