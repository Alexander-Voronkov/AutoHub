using AutoHub.BuildingBlocks.Application;
using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserAccess.Application.Authorization.GetUserPermissions;
using AutoHub.Modules.UserAccess.Application.Configuration.Queries;
using Dapper;

namespace AutoHub.Modules.UserAccess.Application.Authorization.GetAuthenticatedUserPermissions;

internal class GetAuthenticatedUserPermissionsQueryHandler : IQueryHandler<GetAuthenticatedUserPermissionsQuery, List<UserPermissionDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    private readonly IExecutionContextAccessor _executionContextAccessor;

    public GetAuthenticatedUserPermissionsQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IExecutionContextAccessor executionContextAccessor)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _executionContextAccessor = executionContextAccessor;
    }

    public async Task<List<UserPermissionDto>> Handle(GetAuthenticatedUserPermissionsQuery request, CancellationToken cancellationToken)
    {
        if (!_executionContextAccessor.IsAvailable)
        {
            return [];
        }

        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = $""" 
                               SELECT `UserPermission`.`PermissionCode` AS `{nameof(UserPermissionDto.Code)}`
                               FROM `users_UserRoles` AS `UserRole` 
                               INNER JOIN `users_RolesToPermissions` AS `UserPermission` ON `UserPermission`.`RoleCode` = `UserRole`.`RoleCode`
                               WHERE `UserRole`.`UserId` = @UserId
                               """;

        var permissions = await connection.QueryAsync<UserPermissionDto>(
            sql,
            new
            {
                UserId = _executionContextAccessor.UserId
            });

        return permissions.AsList();
    }
}