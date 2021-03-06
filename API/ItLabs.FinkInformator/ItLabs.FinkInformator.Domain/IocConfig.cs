﻿using Autofac;
using Autofac.Integration.WebApi;
using ItLabs.FinkInformator.Core;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Data;
using ItLabs.FinkInformator.Data.Repositories;
using ItLabs.FinkInformator.Domain.Managers;
using System.Reflection;
using System.Web.Http;

namespace ItLabs.FinkInformator.Api.App_Start
{
    public class IocConfig
    {
        //TODO move to domain
        public static void ConfigureIoC(HttpConfiguration config, Assembly assembly)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(assembly);

            
            builder.RegisterType<CoursesManager>().As<ICoursesManager>();
            builder.RegisterType<ProgramsManager>().As<IProgramsManager>();
            builder.RegisterType<CoursesRepository>().As<ICoursesRepository>();
            builder.RegisterType<ProgramsRepository>().As<IProgramsRepository>();
            builder.RegisterType<CoreLog>().As<ICoreLog>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}