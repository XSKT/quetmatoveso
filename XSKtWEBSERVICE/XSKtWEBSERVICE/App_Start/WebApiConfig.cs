using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace XSKtWEBSERVICE
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "XSKT/{controller}/{*key}",
                defaults: new { key = RouteParameter.Optional }
            );
        }
    }
}
