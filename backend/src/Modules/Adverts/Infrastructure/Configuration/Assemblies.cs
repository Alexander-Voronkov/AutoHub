using System.Reflection;
using AutoHub.Modules.Adverts.Application.Contracts;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAdvertsModule).Assembly;
}