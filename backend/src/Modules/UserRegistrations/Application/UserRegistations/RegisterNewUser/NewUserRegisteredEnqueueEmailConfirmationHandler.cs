using AutoHub.Modules.UserRegistrations.Application.Configuration.Commands;
using AutoHub.Modules.UserRegistrations.Application.UserRegistations.SendUserRegistrationConfirmationEmail;
using MediatR;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.RegisterNewUser;

public class NewUserRegisteredEnqueueEmailConfirmationHandler : INotificationHandler<NewUserRegisteredNotification>
{
    private readonly ICommandsScheduler _commandsScheduler;

    public NewUserRegisteredEnqueueEmailConfirmationHandler(ICommandsScheduler commandsScheduler)
    {
        _commandsScheduler = commandsScheduler;
    }

    public async Task Handle(NewUserRegisteredNotification notification, CancellationToken cancellationToken)
    {
        await _commandsScheduler.EnqueueAsync(new SendUserRegistrationConfirmationEmailCommand(
            Guid.NewGuid(),
            notification.DomainEvent.UserRegistrationId,
            notification.DomainEvent.Email,
            notification.DomainEvent.ConfirmLink));
    }
}