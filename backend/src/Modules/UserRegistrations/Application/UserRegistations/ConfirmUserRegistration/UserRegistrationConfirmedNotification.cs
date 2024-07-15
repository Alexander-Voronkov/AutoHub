using AutoHub.BuildingBlocks.Application.Events;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.Events;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.ConfirmUserRegistration;

public class UserRegistrationConfirmedNotification : DomainNotificationBase<UserRegistrationConfirmedDomainEvent>
{
    public UserRegistrationConfirmedNotification(UserRegistrationConfirmedDomainEvent domainEvent, Guid id)
        : base(domainEvent, id)
    {
    }
}