using AutoHub.Modules.UserAccess.Application.Configuration.Commands;
using AutoHub.Modules.UserRegistrations.IntegrationEvents;
using MediatR;

namespace AutoHub.Modules.UserAccess.Application.Users.CreateUser;

public class UserRegistrationConfirmedIntegrationEventHandler : INotificationHandler<UserRegistrationConfirmedIntegrationEvent>
{
    private readonly ICommandsScheduler _commandsScheduler;

    public UserRegistrationConfirmedIntegrationEventHandler(ICommandsScheduler commandsScheduler)
    {
        _commandsScheduler = commandsScheduler;
    }

    public async Task Handle(UserRegistrationConfirmedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        await _commandsScheduler.EnqueueAsync(new
            CreateUserCommand(
                notification.UserRegistrationId,
                notification.Login,
                notification.Email,
                notification.FirstName,
                notification.LastName,
                notification.Password));
    }
}
