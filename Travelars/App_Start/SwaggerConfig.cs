using System.Web.Http;
using WebActivatorEx;
using Travelars;
using Swashbuckle.Application;
using Travelars.Infrastructure;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Travelars
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Travelars");
                    c.OperationFilter<SwaggerAddAuthorizationHeaderOperationFilter>();
                    c.DocumentFilter<AuthTokenOperation>();
                    c.DescribeAllEnumsAsStrings(); // this will do the trick

                })
                .EnableSwaggerUi(c =>
                {
                });          
        }
    }
}
