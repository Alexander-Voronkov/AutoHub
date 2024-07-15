using AutoHub.BuildingBlocks.Application.Events;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.Events;
using Newtonsoft.Json;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.RegisterNewUser;

public class NewUserRegisteredNotification : DomainNotificationBase<NewUserRegisteredDomainEvent>
{
    [JsonConstructor]
    public NewUserRegisteredNotification(NewUserRegisteredDomainEvent domainEvent, Guid id)
        : base(domainEvent, id)
    {
    }
}