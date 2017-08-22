using Autofac;
using Autofac.Integration.WebApi;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ItLabs.FinkInformator.Api.App_Start
{
    public class IocConfig
    {
        //da go pratis config i executing assembly u domain 
        //add as celovo u DOMAIN
        public static void ConfigureIoC(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CoursesManager>().As<ICoursesManager>();
            builder.RegisterType<ProgramsManager>().As<IProgramsManager>();

            //+ repositories

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}