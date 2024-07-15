﻿using Quartz;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Processing.InternalCommands;

[DisallowConcurrentExecution]
public class ProcessInternalCommandsJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessInternalCommandsCommand());
    }
}