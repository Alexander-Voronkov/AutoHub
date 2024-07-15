﻿using System.Reflection;
using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IUserAccessModule).Assembly;
    }
}