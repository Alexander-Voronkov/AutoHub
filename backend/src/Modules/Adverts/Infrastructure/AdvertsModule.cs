using Autofac;
using AutoHub.Modules.Adverts.Application.Contracts;
using AutoHub.Modules.Adverts.Infrastructure.Configuration;
using AutoHub.Modules.Adverts.Infrastructure.Configuration.Processing;
using MediatR;

namespace AutoHub.Modules.Adverts.Infrastructure;

public class AdvertsModule : IAdvertsModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await CommandsExecutor.Execute(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using (var scope = AdvertsCompositionRoot.BeginLifetimeScope())
        {
            var mediator = scope.Resolve<IMediator>();

            return await mediator.Send(query);
        }
    }
}
