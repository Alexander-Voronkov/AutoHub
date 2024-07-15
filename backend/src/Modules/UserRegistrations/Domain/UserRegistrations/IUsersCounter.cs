namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

public interface IUsersCounter
{
    int CountUsersWithLogin(string login);
}