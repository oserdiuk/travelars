using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Travelars.DAL;
using Travelars.Services.Abstract;
using Travelars.Services.AccountServices;

namespace Travelars
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UserService>().As<IUserService>();

            var cfg = AutoMapperConfiguration.RegisterMappingModules();
            builder.RegisterInstance(cfg.CreateMapper()).As<IMapper>();

            builder.RegisterAssemblyTypes(
                Assembly.GetExecutingAssembly())
                    .Where(t =>
                        !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t))
                    .InstancePerLifetimeScope();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
