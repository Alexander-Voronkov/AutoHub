using AutoHub.Modules.UserAccess.Application.Configuration.Commands;
using AutoHub.Modules.UserAccess.Domain;
using AutoHub.Modules.UserAccess.Domain.Users;

namespace AutoHub.Modules.UserAccess.Application.Users.CreateUser;

internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = User.CreateUser(
            command.UserId,
            command.Login,
            command.Password,
            command.Email,
            command.FirstName,
            command.LastName);

        await _userRepository.AddAsync(user);
    }
}