using Autofac;
using AutoHub.BuildingBlocks.Infrastructure.Emails;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Email
{
    internal class EmailModule : Module
    {
        private readonly EmailsConfiguration _configuration;

        public EmailModule(
            EmailsConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSendingService>()
                .As<IEmailSendingService>()
                .WithParameter("configuration", _configuration)
                .SingleInstance();
        }
    }
}