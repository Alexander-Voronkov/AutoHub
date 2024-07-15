using AutoHub.API.Configuration.Authorization;
using AutoHub.Modules.UserRegistrations.Application.Contracts;
using AutoHub.Modules.UserRegistrations.Application.UserRegistations.ConfirmUserRegistration;
using AutoHub.Modules.UserRegistrations.Application.UserRegistations.RegisterNewUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoHub.API.Modules.UserAccess;

[Route("userAccess/registrations")]
[ApiController]
public class UserRegistrationsController : ControllerBase
{
    private readonly IRegistrationsModule _registrationsModule;

    public UserRegistrationsController(IRegistrationsModule registrationsModule)
    {
        _registrationsModule = registrationsModule;
    }

    [NoPermissionRequired]
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RegisterNewUser(RegisterNewUserRequest request)
    {
        await _registrationsModule.ExecuteCommandAsync(new RegisterNewUserCommand(
            request.Login,
            request.Password,
            request.Email,
            request.FirstName,
            request.LastName,
            request.ConfirmLink));

        return Ok();
    }

    [NoPermissionRequired]
    [AllowAnonymous]
    [HttpPatch("{userRegistrationId}/confirm")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ConfirmRegistration(Guid userRegistrationId)
    {
        await _registrationsModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(userRegistrationId));

        return Ok();
    }
}