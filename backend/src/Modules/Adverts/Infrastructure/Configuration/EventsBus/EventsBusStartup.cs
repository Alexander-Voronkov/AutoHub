using Autofac;
using AutoHub.BuildingBlocks.Infrastructure.EventBus;
using Serilog;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration.EventsBus;

public static class EventsBusStartup
{
    public static void Initialize(
        ILogger logger)
    {
        SubscribeToIntegrationEvents(logger);
    }

    private static void SubscribeToIntegrationEvents(ILogger logger)
    {
        var eventBus = AdvertsCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
        where T : IntegrationEvent
    {
        logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>());
    }
}