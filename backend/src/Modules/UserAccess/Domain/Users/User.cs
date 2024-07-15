using AutoHub.BuildingBlocks.Domain;
using AutoHub.Modules.UserAccess.Domain.Users;
using AutoHub.Modules.UserAccess.Domain.Users.Events;

namespace AutoHub.Modules.UserAccess.Domain;

public class User : Entity, IAggregateRoot
{
    public UserId Id { get; private set; }

    private string _login;

    private string _password;

    private string _email;

    private bool _isActive;

    private string _firstName;

    private string _lastName;

    private string _name;

    //private List<string> _profilePicturesLinks;

    private List<UserRole> _roles;

    private User()
    {
        // Only for EF.
    }

    public static User CreateAdmin(
        string login,
        string password,
        string email,
        string firstName,
        string lastName,
        string name)
    {
        return new User(
            Guid.NewGuid(),
            login,
            password,
            email,
            firstName,
            lastName,
            name,
            UserRole.Administrator);
    }

    public static User CreateUser(
        Guid userId,
        string login,
        string password,
        string email,
        string firstName,
        string lastName)
    {
        return new User(
            userId,
            login,
            password,
            email,
            firstName,
            lastName,
            $"{firstName} {lastName}",
            UserRole.Member);
    }

    private User(
        Guid id,
        string login,
        string password,
        string email,
        string firstName,
        string lastName,
        string name,
        UserRole role)
    {
        this.Id = new UserId(id);
        _login = login;
        _password = password;
        _email = email;
        _firstName = firstName;
        _lastName = lastName;
        _name = name;

        _isActive = true;

        _roles = [role];

        this.AddDomainEvent(new UserCreatedDomainEvent(this.Id));
    }

    public void EnableUser()
    {
        _isActive = true;
    }

    public void DisableUser()
    {
        _isActive = false;
    }

    public void AddRole(UserRole userRole)
    {
        _roles.Add(userRole);
    }
}