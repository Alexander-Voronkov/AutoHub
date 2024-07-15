using Autofac;
using AutoHub.Modules.Adverts.Application;
using AutoHub.Modules.Adverts.Domain;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration.Authentication;

internal class AuthenticationModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserContext>()
            .As<IUserContext>()
            .InstancePerLifetimeScope();
    }
}
