using Autofac;
using AutoHub.BuildingBlocks.Application;
using AutoHub.BuildingBlocks.Infrastructure;
using AutoHub.BuildingBlocks.Infrastructure.EventBus;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Authentication;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.DataAccess;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.EventsBus;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Logging;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Mediation;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Processing;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Processing.Outbox;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Quartz;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration;

public class AdvertsStartup
{
    private static IContainer _container;

    public static void Initialize(
        string connectionString,
        IExecutionContextAccessor executionContextAccessor,
        ILogger logger,
        IEventsBus eventsBus,
        long? internalProcessingPoolingInterval = null)
    {
        var moduleLogger = logger.ForContext("Module", "Adverts");

        ConfigureCompositionRoot(
            connectionString,
            executionContextAccessor,
            moduleLogger,
            eventsBus);

        QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

        EventsBusStartup.Initialize(moduleLogger);
    }

    public static void Stop()
    {
        QuartzStartup.StopQuartz();
    }

    private static void ConfigureCompositionRoot(
        string connectionString,
        IExecutionContextAccessor executionContextAccessor,
        ILogger logger,
        IEventsBus eventsBus)
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Adverts")));

        var loggerFactory = new SerilogLoggerFactory(logger);
        containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
        containerBuilder.RegisterModule(new ProcessingModule());
        containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
        containerBuilder.RegisterModule(new MediatorModule());
        containerBuilder.RegisterModule(new AuthenticationModule());

        var domainNotificationsMap = new BiDictionary<string, Type>();
        containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));
        containerBuilder.RegisterModule(new QuartzModule());

        containerBuilder.RegisterInstance(executionContextAccessor);

        _container = containerBuilder.Build();

        AdvertsCompositionRoot.SetContainer(_container);
    }
}