using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations.Rules;

public class UserEmailMustBeUniqueRule : IBusinessRule
{
    private readonly IUsersCounter _usersCounter;
    private readonly string _login;

    internal UserEmailMustBeUniqueRule(IUsersCounter usersCounter, string login)
    {
        _usersCounter = usersCounter;
        _login = login;
    }

    public bool IsBroken() => _usersCounter.CountUsersWithLogin(_login) > 0;

    public string Message => "User`s login must be unique";
}