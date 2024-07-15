using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.Events;

public class UserRegistrationConfirmedDomainEvent : DomainEventBase
{
    public UserRegistrationId UserRegistrationId { get; }

    public string Login { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Name { get; }

    public string Password { get; }

    public DateTime RegisterDate { get; }

    public UserRegistrationConfirmedDomainEvent(
        UserRegistrationId userRegistrationId,
        string login,
        string email,
        string firstName,
        string lastName,
        string name,
        string password,
        DateTime registerDate)
    {
        UserRegistrationId = userRegistrationId;
        Login = login;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        RegisterDate = registerDate;
        Password = password;
    }
}