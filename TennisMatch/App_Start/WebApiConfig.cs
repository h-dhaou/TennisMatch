using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using TennisMatch.Services;

namespace TennisMatch
{
    public static class WebApiConfig
    {
        public static IContainer Container { get; set; }

        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Reset Formatters
            var formatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            config.Formatters.Clear();

            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Add(formatter);

            var builder = new ContainerBuilder();

            builder.RegisterType<TennisService>().As<ITennisService>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
