using AutoHub.BuildingBlocks.Infrastructure.EventBus;

namespace AutoHub.Modules.UserRegistrations.IntegrationEvents;

public class UserRegistrationConfirmedIntegrationEvent : IntegrationEvent
{
    public Guid UserRegistrationId { get; }

    public string Login { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Name { get; }

    public string Password { get; }

    public UserRegistrationConfirmedIntegrationEvent(
        Guid id,
        DateTime occurredOn,
        Guid userRegistrationId,
        string login,
        string email,
        string firstName,
        string lastName,
        string name,
        string password)
        : base(id, occurredOn)
    {
        Login = login;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        Password = password;
        UserRegistrationId = userRegistrationId;
    }
}