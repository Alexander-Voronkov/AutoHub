using AutoHub.Modules.UserRegistrations.Application.Contracts;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}