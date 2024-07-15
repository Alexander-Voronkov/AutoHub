using Autofac;
using AutoHub.BuildingBlocks.Application;
using AutoHub.BuildingBlocks.Infrastructure;
using AutoHub.BuildingBlocks.Infrastructure.Emails;
using AutoHub.BuildingBlocks.Infrastructure.EventBus;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.DataAccess;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.EventsBus;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Logging;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Mediation;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Processing;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Processing.Outbox;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Quartz;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Security;
using Serilog;

namespace AutoHub.Modules.UserAccess.Infrastructure.Configuration
{
    public class UserAccessStartup
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
            var moduleLogger = logger.ForContext("Module", "UserAccess");

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

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "UserAccess")));

            var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new OutboxModule(new BiDictionary<string, Type>()));

            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);
        }
    }
}