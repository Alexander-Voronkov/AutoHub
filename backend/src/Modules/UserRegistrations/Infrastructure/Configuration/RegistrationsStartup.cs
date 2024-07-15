using Autofac;
using AutoHub.BuildingBlocks.Application;
using AutoHub.BuildingBlocks.Infrastructure;
using AutoHub.BuildingBlocks.Infrastructure.Emails;
using AutoHub.BuildingBlocks.Infrastructure.EventBus;
using AutoHub.Modules.UserRegistrations.Application.UserRegistations.ConfirmUserRegistration;
using AutoHub.Modules.UserRegistrations.Application.UserRegistations.RegisterNewUser;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.DataAccess;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Domain;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Email;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.EventsBus;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Logging;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Mediation;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Processing;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Processing.Outbox;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Quartz;
using Serilog;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration
{
    public class RegistrationsStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            string textEncryptionKey,
            IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {
            var moduleLogger = logger.ForContext("Module", "Registrations");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                logger,
                emailsConfiguration,
                textEncryptionKey,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

            EventsBusStartup.Initialize(moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            string textEncryptionKey,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Registrations")));

            var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();
            domainNotificationsMap.Add("UserRegistrationConfirmedNotification", typeof(UserRegistrationConfirmedNotification));
            domainNotificationsMap.Add("NewUserRegisteredNotification", typeof(NewUserRegisteredNotification));
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            RegistrationsCompositionRoot.SetContainer(_container);
        }
    }
}