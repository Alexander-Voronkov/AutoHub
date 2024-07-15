using AutoHub.API.Configuration.Authorization;
using AutoHub.Modules.UserAccess.Application.Authorization.GetAuthenticatedUserPermissions;
using AutoHub.Modules.UserAccess.Application.Authorization.GetUserPermissions;
using AutoHub.Modules.UserAccess.Application.Contracts;
using AutoHub.Modules.UserAccess.Application.Users.GetAuthenticatedUser;
using AutoHub.Modules.UserAccess.Application.Users.GetUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.API.Modules.UserAccess;

[Route("api/userAccess/authenticatedUser")]
[ApiController]
public class AuthenticatedUserController : ControllerBase
{
    private readonly IUserAccessModule _userAccessModule;

    public AuthenticatedUserController(IUserAccessModule userAccessModule)
    {
        _userAccessModule = userAccessModule;
    }

    [HasPermission(nameof(GetAuthenticatedUser))]
    [HttpGet("")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthenticatedUser()
    {
        var user = await _userAccessModule.ExecuteQueryAsync(new GetAuthenticatedUserQuery());

        return Ok(user);
    }

    [HasPermission(nameof(GetAuthenticatedUserPermissions))]
    [HttpGet("permissions")]
    [ProducesResponseType(typeof(List<UserPermissionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthenticatedUserPermissions()
    {
        var permissions = await _userAccessModule.ExecuteQueryAsync(new GetAuthenticatedUserPermissionsQuery());

        return Ok(permissions);
    }
}