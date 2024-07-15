using AutoHub.Modules.Adverts.Application.Contracts;

namespace AutoHub.Modules.Adverts.Application.Configuration.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(ICommand command);

    Task EnqueueAsync<T>(ICommand<T> command);
}