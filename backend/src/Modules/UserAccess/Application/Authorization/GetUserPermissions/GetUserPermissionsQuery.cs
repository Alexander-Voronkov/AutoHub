using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Application.Authorization.GetUserPermissions;

public class GetUserPermissionsQuery : QueryBase<List<UserPermissionDto>>
{
    public GetUserPermissionsQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}