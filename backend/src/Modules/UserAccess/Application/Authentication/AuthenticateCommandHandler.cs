using System.Security.Claims;
using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserAccess.Application.Authorization.GetUserRoles;
using AutoHub.Modules.UserAccess.Application.Configuration.Commands;
using AutoHub.Modules.UserAccess.Application.Contracts;
using Dapper;
using MediatR;

namespace AutoHub.Modules.UserAccess.Application.Authentication;

internal class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IMediator _mediator;

    internal AuthenticateCommandHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IMediator mediator)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _mediator = mediator;
    }

    public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = $"""
                                SELECT 
                                   `User`.`Id` as `{nameof(UserDto.Id)}`,
                                   `User`.`Login` as `{nameof(UserDto.Login)}`,
                                   `User`.`Name` as `{nameof(UserDto.Name)}`,
                                   `User`.`Email` as `{nameof(UserDto.Email)}`,
                                   `User`.`IsActive` as `{nameof(UserDto.IsActive)}`,
                                   `User`.`Password`  as `{nameof(UserDto.Password)}`
                               FROM `users_Users` AS `User` 
                               WHERE `User`.`Login` = @Login
                            """;

        var user = await connection.QuerySingleOrDefaultAsync<UserDto>(
            sql,
            new
            {
                request.Login,
            });

        if (user == null)
        {
            return new AuthenticationResult("Incorrect login or password");
        }

        if (!user.IsActive)
        {
            return new AuthenticationResult("User is not active");
        }

        if (!PasswordManager.VerifyHashedPassword(user.Password, request.Password))
        {
            return new AuthenticationResult("Incorrect login or password");
        }

        var userRoles = await _mediator.Send(new GetUserRolesQuery(user.Id));

        user.Claims =
        [
            new Claim(CustomClaimTypes.Name, user.Name),
            new Claim(CustomClaimTypes.Email, user.Email),
            new Claim(CustomClaimTypes.Roles, userRoles.Aggregate(string.Empty, (acc, role) => acc + ", " + role.RoleCode))
        ];

        return new AuthenticationResult(user);
    }
}