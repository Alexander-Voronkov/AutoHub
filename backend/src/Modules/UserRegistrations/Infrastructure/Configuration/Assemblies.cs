using System.Reflection;
using AutoHub.Modules.UserRegistrations.Application.Contracts;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IRegistrationsModule).Assembly;
    }
}