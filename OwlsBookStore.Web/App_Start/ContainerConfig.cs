using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OwlsBookStore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OwlsBookStore.Web
{
    public class ContainerConfig
    {
        internal static void RegisterCountainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlOwlsBookStoreData>()
                   .As<IOwlsBookStoreData>()
                   .InstancePerRequest();
            builder.RegisterType<OwlsBookStoreDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            /* https://davidsekar.com/aspnetcore/register-automapper-profiles-with-autofac
             *  --var autoMapperProfiles = assembliesTypes
                --    .Select(p => (Profile)Activator.CreateInstance(p)).ToList();

                builder.Register(ctx => new MapperConfiguration(cfg =>
                {
                    --foreach (var profile in autoMapperProfiles)
                    --{
                        // use name of the class for auto mapping configuration
                        cfg.AddProfile(profile);
                    --}
                }));

                builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
             */
        }
    }
}