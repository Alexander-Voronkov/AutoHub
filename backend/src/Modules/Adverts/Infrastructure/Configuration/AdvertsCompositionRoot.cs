﻿using Autofac;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration;

internal static class AdvertsCompositionRoot
{
    private static IContainer _container;

    internal static void SetContainer(IContainer container)
    {
        _container = container;
    }

    internal static ILifetimeScope BeginLifetimeScope()
    {
        return _container.BeginLifetimeScope();
    }
}