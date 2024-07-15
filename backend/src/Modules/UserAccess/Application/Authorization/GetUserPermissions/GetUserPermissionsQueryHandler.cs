using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserAccess.Application.Configuration.Queries;
using AutoHub.Modules.UserAccess.Application.Contracts;
using Dapper;

namespace AutoHub.Modules.UserAccess.Application.Authorization.GetUserPermissions;

internal class GetUserPermissionsQueryHandler : IQueryHandler<GetUserPermissionsQuery, List<UserPermissionDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUserPermissionsQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<UserPermissionDto>> Handle(
        GetUserPermissionsQuery query,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = $"""
                                SELECT `UserPermission`.`PermissionCode` AS `{nameof(UserPermissionDto.Code)}`
                                FROM `users_UserRoles` AS `UserRole` 
                                INNER JOIN `users_RolesToPermissions` AS `UserPermission` ON `UserPermission`.`RoleCode` = `UserRole`.`RoleCode`
                                WHERE `UserRole`.`UserId` = @UserId
                            """;
        var permissions = await connection.QueryAsync<UserPermissionDto>(sql, new { query.UserId });

        return permissions.AsList();
    }
}