using AutoHub.Modules.UserAccess.Application.Authorization.GetUserPermissions;
using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Application.Authorization.GetAuthenticatedUserPermissions;

public class GetAuthenticatedUserPermissionsQuery : QueryBase<List<UserPermissionDto>>
{
}