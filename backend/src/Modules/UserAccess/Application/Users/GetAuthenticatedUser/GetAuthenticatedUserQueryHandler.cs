using System.Security.Claims;
using AutoHub.BuildingBlocks.Application;
using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserAccess.Application.Authentication;
using AutoHub.Modules.UserAccess.Application.Authorization.GetUserRoles;
using AutoHub.Modules.UserAccess.Application.Configuration.Queries;
using AutoHub.Modules.UserAccess.Application.Contracts;
using Dapper;
using MediatR;

namespace AutoHub.Modules.UserAccess.Application.Users.GetAuthenticatedUser;

internal class GetAuthenticatedUserQueryHandler : IQueryHandler<GetAuthenticatedUserQuery, UserDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    private readonly IExecutionContextAccessor _executionContextAccessor;

    private readonly IMediator _mediator;

    public GetAuthenticatedUserQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IExecutionContextAccessor executionContextAccessor,
        IMediator mediator)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _executionContextAccessor = executionContextAccessor;
        _mediator = mediator;
    }

    public async Task<UserDto> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = $"""
                                SELECT 
                                    `User`.`Id` as `{nameof(UserDto.Id)}`, 
                                    `User`.`IsActive` as `{nameof(UserDto.IsActive)}`,
                                    `User`.`Login` as `{nameof(UserDto.Login)}`,
                                    `User`.`Email` as `{nameof(UserDto.Email)}`,
                                    `User`.`Name` as `{nameof(UserDto.Name)}`
                                FROM `users_Users` AS `User`
                                WHERE `User`.`Id` = @UserId
                                """;

        var roles = await _mediator.Send(new GetUserRolesQuery(_executionContextAccessor.UserId));

        var user = await connection.QuerySingleAsync<UserDto>(sql, new
        {
            _executionContextAccessor.UserId
        });

        user.Claims = [
            new Claim(CustomClaimTypes.Roles, string.Join(",", roles.Select(x => x.RoleCode)))
        ];

        return user;
    }
}