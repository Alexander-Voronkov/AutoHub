using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Application.Authentication;

public class AuthenticateCommand : CommandBase<AuthenticationResult>
{
    public AuthenticateCommand(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public string Login { get; }

    public string Password { get; }
}