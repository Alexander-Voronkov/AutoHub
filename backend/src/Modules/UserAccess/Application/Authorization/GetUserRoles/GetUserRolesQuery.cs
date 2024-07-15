using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Application.Authorization.GetUserRoles;

public class GetUserRolesQuery : QueryBase<List<UserRoleDto>>
{
    public GetUserRolesQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}