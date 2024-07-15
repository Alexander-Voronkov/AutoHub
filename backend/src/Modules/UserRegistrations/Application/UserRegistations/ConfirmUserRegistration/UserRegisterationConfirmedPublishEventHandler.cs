using AutoHub.BuildingBlocks.Infrastructure.EventBus;
using AutoHub.Modules.UserRegistrations.IntegrationEvents;
using MediatR;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.ConfirmUserRegistration;

public class UserRegisterationConfirmedPublishEventHandler : INotificationHandler<UserRegistrationConfirmedNotification>
{
    private readonly IEventsBus _eventsBus;

    public UserRegisterationConfirmedPublishEventHandler(IEventsBus eventsBus)
    {
        _eventsBus = eventsBus;
    }

    public async Task Handle(UserRegistrationConfirmedNotification notification, CancellationToken cancellationToken)
    {
        await _eventsBus.Publish(new UserRegistrationConfirmedIntegrationEvent(
            notification.Id,
            notification.DomainEvent.OccurredOn,
            notification.DomainEvent.UserRegistrationId.Value,
            notification.DomainEvent.Login,
            notification.DomainEvent.Email,
            notification.DomainEvent.FirstName,
            notification.DomainEvent.LastName,
            notification.DomainEvent.Name,
            notification.DomainEvent.Password));
    }
}