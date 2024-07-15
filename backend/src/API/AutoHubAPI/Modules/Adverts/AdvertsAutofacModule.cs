using Autofac;
using AutoHub.Modules.Adverts.Application.Contracts;
using AutoHub.Modules.Adverts.Infrastructure;

namespace AutoHub.API.Modules.Adverts;

public class AdvertsAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AdvertsModule>()
            .As<IAdvertsModule>()
            .InstancePerLifetimeScope();
    }
}