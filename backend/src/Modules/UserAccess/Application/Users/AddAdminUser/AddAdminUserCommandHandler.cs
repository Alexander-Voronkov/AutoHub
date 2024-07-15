using AutoHub.Modules.UserAccess.Application.Authentication;
using AutoHub.Modules.UserAccess.Application.Configuration.Commands;
using AutoHub.Modules.UserAccess.Domain;
using AutoHub.Modules.UserAccess.Domain.Users;

namespace AutoHub.Modules.UserAccess.Application.Users.AddAdminUser;

internal class AddAdminUserCommandHandler : ICommandHandler<AddAdminUserCommand>
{
    private readonly IUserRepository _userRepository;

    public AddAdminUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(AddAdminUserCommand command, CancellationToken cancellationToken)
    {
        var password = PasswordManager.HashPassword(command.Password);

        var user = User.CreateAdmin(
            command.Login,
            password,
            command.Email,
            command.FirstName,
            command.LastName,
            command.Name);

        await _userRepository.AddAsync(user);
    }
}