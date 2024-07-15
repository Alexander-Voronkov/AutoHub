using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserAccess.Application.Configuration.Queries;
using Dapper;

namespace AutoHub.Modules.UserAccess.Application.Authorization.GetUserRoles;

public class GetUserRolesQueryHandler : IQueryHandler<GetUserRolesQuery, List<UserRoleDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUserRolesQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<UserRoleDto>> Handle(GetUserRolesQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = $"""
                                SELECT `UserRole`.`RoleCode` AS `{nameof(UserRoleDto.RoleCode)}`
                                FROM `users_UserRoles` AS `UserRole`
                                WHERE `UserRole`.`UserId` = @UserId
                            """;

        var roles = await connection.QueryAsync<UserRoleDto>(
            sql,
            new
            {
                UserId = query.UserId,
            });

        return roles.AsList();
    }
}
