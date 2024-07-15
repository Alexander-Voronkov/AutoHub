using Autofac;
using AutoHub.Modules.UserAccess.Application.Contracts;
using AutoHub.Modules.UserAccess.Infrastructure;
using AutoHub.Modules.UserRegistrations.Application.Contracts;
using AutoHub.Modules.UserRegistrations.Infrastructure;

namespace AutoHub.API.Modules.UserAccess;

public class UserAccessAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserAccessModule>()
            .As<IUserAccessModule>()
            .InstancePerLifetimeScope();

        builder.RegisterType<RegistrationsModule>()
            .As<IRegistrationsModule>()
            .InstancePerLifetimeScope();
    }
}