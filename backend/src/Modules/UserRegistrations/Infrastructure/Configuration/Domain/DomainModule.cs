using Autofac;
using AutoHub.Modules.UserRegistrations.Application.UserRegistations;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Domain
{
    internal class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersCounter>()
                .As<IUsersCounter>()
                .InstancePerLifetimeScope();
        }
    }
}