using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Processing;
using Quartz;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Email;

[DisallowConcurrentExecution]
public class ProcessEmailsJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await CommandsExecutor.Execute(new ProcessEmailsCommand());
    }
}
