using System.Web.Http;
using WebActivatorEx;
using ItLabs.FinkInformator.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ItLabs.FinkInformator.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ItLabs.FinkInformator.Api");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\ItLabs.FinkInformator.Api.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                }).EnableSwaggerUi();
        }
    }
}
