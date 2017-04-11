using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using OpenAPI.ExceptionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OpenAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            IsoDateTimeConverter dtconvert = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff''"
            };
            json.SerializerSettings.Converters.Add(dtconvert);

            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ValidationFilter());

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
