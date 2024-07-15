using Autofac;
using AutoHub.Modules.UserRegistrations.Application.Contracts;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Processing;
using MediatR;

namespace AutoHub.Modules.UserRegistrations.Infrastructure
{
    public class RegistrationsModule : IRegistrationsModule
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
            using (var scope = RegistrationsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}